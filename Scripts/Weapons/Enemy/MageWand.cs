using UnityEngine;

public class MageWand : EnemyGun {
    public Transform[] FirePoints;

    public override void Shoot() {
        foreach (Transform firePoint in FirePoints) {
            GameObject bullet = Instantiate(bulletPerfab, firePoint.position, firePoint.rotation);
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
            bulletScript.Damage = Damage;
            bulletScript.lifespan = BulletLifespan;

            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}