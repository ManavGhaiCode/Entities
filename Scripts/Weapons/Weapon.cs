using System;
using UnityEngine;

public class Weapon : MonoBehaviour {
    public int bulletDamage = 5;
    public float bulletSpeed = 10f;
    public float bulletLifespan = 1f;
    public float TimeBetweenShots = .2f;
    public GameObject BulletPrefab;
    public Transform firePoint;

    public bool IsInaccurate = false;

    private float _TimeBetweenShots = .2f;
    private bool isShooting;

    private float TimeToShoot;

    private GameObject player;

    private float RandomRange(float minimum, float maximum) {
        System.Random rand = new System.Random();
        return (float)(rand.NextDouble() * (maximum - minimum) + minimum);
    }

    private void Start() {
        _TimeBetweenShots = TimeBetweenShots;
        TimeToShoot = Time.time + _TimeBetweenShots;

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        isShooting = Input.GetMouseButton(0);
    }

    private void FixedUpdate() {
        if (isShooting && Time.time >= TimeToShoot) {
            TimeToShoot = Time.time + _TimeBetweenShots;

            Shoot();
            player.GetComponent<Animator>().SetBool("Shooting", true);

        } else {
            player.GetComponent<Animator>().SetBool("Shooting", false);
        }
    }

    public virtual void Shoot() {
        Vector2 Offset = Vector2.zero;

        if (IsInaccurate) {
            Offset.x = (float)RandomRange(-1, 1);
            Offset.y = (float)RandomRange(-1, 1);
        }

        GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Damage = bulletDamage;
        bulletScript.lifespan = bulletLifespan;

        Vector2 Up = (Vector2)firePoint.up + (Offset.normalized * 0.1f);

        bullet.GetComponent<Rigidbody2D>().AddForce(Up * bulletSpeed, ForceMode2D.Impulse);
    }
}