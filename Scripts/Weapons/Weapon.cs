using UnityEngine;

public class Weapon : MonoBehaviour {
    public int bulletDamage = 5;
    public float bulletSpeed = 10f;
    public float bulletLifespan = 1f;
    public float TimeBetweenShots = .2f;
    public GameObject BulletPrefab;
    public Transform firePoint;

    private float _TimeBetweenShots = .2f;
    private float TimeToShoot;
    private bool isShooting = false;

    private GameObject Player;

    private void Start() {
        _TimeBetweenShots = TimeBetweenShots;
        TimeToShoot = Time.time + _TimeBetweenShots;

        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        isShooting = Input.GetMouseButton(0);
    }

    private void FixedUpdate() {
        if (isShooting && Time.time >= TimeToShoot) {
            TimeToShoot = Time.time + _TimeBetweenShots;

            GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Damage = bulletDamage;
            bulletScript.lifespan = bulletLifespan;

            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}