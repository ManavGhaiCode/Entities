using UnityEngine;

public class BalstEnemy : Enemy {
    public float RotationSpeed;
    public float ExplotionDistance = 5f;

    public Transform[] FirePoints;
    public GameObject bulletPerfab;

    private void FixedUpdate() {
        Vector2 MoveDirection = transform.position - player.position;
        float Angle = Vector3.Cross(MoveDirection, transform.up).z;

        rb.angularVelocity = Angle * RotationSpeed;
        rb.velocity = transform.up * speed;

        if (Vector2.Distance(transform.position, player.position) <= ExplotionDistance) {
            Explode();
        }
    }

    private void Explode() {
        foreach (Transform firePoint in FirePoints) {
            GameObject bullet = Instantiate(bulletPerfab, firePoint.position, firePoint.rotation);
            EnemyBullet bulletScript = bullet.GetComponent<EnemyBullet>();
            bulletScript.Damage = Damage;
            bulletScript.lifespan = 1f;

            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * ( speed * 2 ), ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }
}