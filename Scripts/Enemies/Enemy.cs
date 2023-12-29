using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform player;
    public int Health;

    public int Damage = 10;
    public Rigidbody2D rb;

    public Animator anim;

    public float speed = 5f;

    public void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int Damage) {
        Health -= Damage;
        anim.SetTrigger("Hit");

        if (Health <= 0) {
            Destroy(gameObject);
        }
    }
}