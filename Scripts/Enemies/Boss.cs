using System.Collections;
using UnityEngine;

public class Boss : Enemy {
    public float TimeBetweenAttacks;
    public Transform[] FirePoints;
    public GameObject bulletPerfab;
    public float bulletSpeed;
    public Transform SpawnPoint;

    public GameObject[] spawnEnemies;

    private float TimeToAttack;

    private void Start() {
        base.Start();
        TimeToAttack = Time.time + TimeBetweenAttacks;
    }

    private void FixedUpdate() {
        if (player == null) { return; }

        if (TimeToAttack <= Time.time) {
            int Attack = Random.Range(0, 3);

            if (Attack == 0) {
                BulletStorm();
            } else if (Attack == 1) {
                SpawnEnemy();
            } else {
                StartCoroutine(MeleeAttack());
            }

            TimeToAttack = Time.time + TimeBetweenAttacks;
        }
    }

    private void BulletStorm() {
        foreach (Transform firePoint in FirePoints) {
            GameObject bullet = Instantiate(bulletPerfab, firePoint.position, firePoint.rotation);
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
            bulletScript.Damage = Damage;
            bulletScript.lifespan = 2f;

            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }

    private void SpawnEnemy() {
        int EnemyToSpawn = Random.Range(0, spawnEnemies.Length);
        Instantiate(spawnEnemies[EnemyToSpawn], SpawnPoint.position, SpawnPoint.rotation);
    }

    private IEnumerator MeleeAttack() {
        Vector2 currentPlayerPosition = player.position;
        Vector2 originalPosition = transform.position;

        float percent = 0f;

        while (percent <= 1) {
            if (player != null) {
                percent += Time.deltaTime * speed / 2;
                float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;

                transform.position = Vector2.Lerp(originalPosition, currentPlayerPosition, interpolation);
                yield return null;
            } else {
                yield return null;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Player playerScript = hitInfo.GetComponent<Player>();

        if (playerScript != null) {
            playerScript.TakeDamage(1);
        }
    }
}