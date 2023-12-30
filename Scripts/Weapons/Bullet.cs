using UnityEngine;

public class Bullet : MonoBehaviour {
    public int Damage;
    public float lifespan;

    public GameObject ParticleEffect;

    private void Start() {
        Invoke("Die", lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("PlayerBullet")) return;

        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null) {
            enemy.TakeDamage(Damage);
        }

        Die();
    }

    private void Die() {
        Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}