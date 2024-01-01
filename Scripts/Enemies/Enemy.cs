using System;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform player;
    public int Health;

    public int Damage = 10;

    public GameObject[] Drops;
    public float DropChance = .4f;
    public bool WillDrop = false;

    [HideInInspector]
    public Rigidbody2D rb;

    [HideInInspector]
    public Animator anim;

    [HideInInspector]
    public Player playerScript;

    private CameraController camera;

    public float speed = 5f;

    public float RandomRange(float minimum, float maximum) {
        System.Random rand = new System.Random();
        return (float)(rand.NextDouble() * (maximum - minimum) + minimum);
    }

    public void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerScript = GameObject.FindWithTag("Player").GetComponent<Player>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        camera = GameObject.FindWithTag("Camera").GetComponent<CameraController>();
    }

    public void TakeDamage(int Damage) {
        Health -= Damage;
        anim.SetTrigger("Hit");

        if (Health <= 0) {
            Die();
        }
    }

    public void Die() {
        if (WillDrop) {
            if (RandomRange(0, 1) < DropChance) {
                int DropIndex = UnityEngine.Random.Range(0, Drops.Length);
                Instantiate(Drops[DropIndex], transform.position, transform.rotation);
            }
        }

        camera.Shake(1);
        Destroy(gameObject);
    }
}