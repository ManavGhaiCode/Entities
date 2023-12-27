using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 MoveInput;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        Vector2 Force = MoveInput.normalized;
        Force *= speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + Force);
    }
}
