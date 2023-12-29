using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public int Damage;
    public float lifespan;
    
    public GameObject ParticleEffect;

    private void Start() {
        Invoke("Die", lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        if (hitInfo.CompareTag("EnemyBullet") || hitInfo.CompareTag("Enemy")) {
            return;
        }

        Player player = hitInfo.GetComponent<Player>();
        
        if (player != null) {
            player.TakeDamage(Damage);
        }

        Die();
    }

    private void Die() {
        Instantiate(ParticleEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}