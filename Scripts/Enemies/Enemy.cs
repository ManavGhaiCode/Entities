using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform player;
    public int Health;

    public Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int Damage) {
        Health -= Damage;

        if (Health <= 0) {
            Destroy(gameObject);
        }
    }
}