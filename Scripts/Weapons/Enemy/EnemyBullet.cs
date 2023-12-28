using UnityEngine;

public class EnemyBullet : MonoBehaviour {
    public int Damage;
    public float lifespan;

    private void Start() {
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Player player = hitInfo.GetComponent<Player>();
        
        if (player != null) {
            player.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}