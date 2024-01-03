using UnityEngine;

public class EnemyGun : MonoBehaviour {
    public GameObject bulletPerfab;
    public float BulletLifespan;
    public float bulletSpeed;

    public Transform FirePoint;
    public int Damage;

    public virtual void Shoot() {
        GameObject bullet = Instantiate(bulletPerfab, FirePoint.position, FirePoint.rotation);
        EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
        bulletScript.Damage = Damage;
        bulletScript.lifespan = BulletLifespan;

        bullet.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * bulletSpeed, ForceMode2D.Impulse);
        GameObject.FindWithTag("Main").GetComponent<AudioManager>().Play("Bullet");
    }
}