using UnityEngine;

public class BalstEnemy : Enemy {
    public float RotationSpeed;

    private void FixedUpdate() {
        Vector2 MoveDirection = transform.position - player.position;
        float Angle = Vector3.Cross(MoveDirection, transform.up).z;

        rb.angularVelocity = Angle * RotationSpeed;
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Player playerScript = hitInfo.GetComponent<Player>();

        if (playerScript != null) {
            playerScript.TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}