using UnityEngine;

public class Bullet : MonoBehaviour {
    public int Damage;
    public float lifespan;

    private void Start() {
        Destroy(gameObject, lifespan);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Enemy enemy = hitInfo.GetComponent<Enemy>();

        if (enemy != null) {
            enemy.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}