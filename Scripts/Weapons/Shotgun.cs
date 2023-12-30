using UnityEngine;

public class Shotgun : Weapon {
    public override void Shoot() {
        for (int i = 0; i < 5; i++) {
            int NewRotation = Random.Range(-40, 40);
            firePoint.rotation = Quaternion.Euler(new Vector3 (0, 0, NewRotation));

            GameObject bullet = Instantiate(BulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            bulletScript.Damage = bulletDamage;
            bulletScript.lifespan = bulletLifespan;

            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * bulletSpeed, ForceMode2D.Impulse);
        }
    }
}