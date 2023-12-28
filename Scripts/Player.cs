using UnityEngine;

public class Player : MonoBehaviour {
    public int _Health = 100;

    public float speed = 5f;
    public Transform WeaponPosition;

    private Rigidbody2D rb;
    private Vector2 MoveInput;

    private int Health = 100;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Health = _Health;
    }

    private void Update() {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate() {
        Vector2 Force = MoveInput.normalized;
        Force *= speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + Force);

        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 LookDir = (Vector2)transform.position - MousePos;

        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg + 90f;
        rb.rotation = angle;
    }

    public void TakeWeapon(GameObject WeaponRef) {
        Transform Weapon = Instantiate(WeaponRef, WeaponPosition.position, transform.rotation).GetComponent<Transform>();
        Weapon.SetParent(transform);
    }

    public void TakeDamage(int Damage) {
        Health -= Damage;

        if (Health <= 0) {
            Destroy(gameObject);
        }
    }
}