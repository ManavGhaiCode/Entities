using System;
using UnityEngine;

public class Player : MonoBehaviour {
    public int _Health = 100;

    public int Ammo = 30;
    public float speed = 5f;
    public Transform WeaponPosition;

    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 MoveInput;

    private GameObject[] Guns;
    private GameObject CurrentWeapon;
    private int WeaponIndex;

    private bool CanTakeDamage = true;
    private int Health = 100;


    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        Health = _Health;
        Guns = new GameObject[0];
        WeaponIndex = -1;
    }

    private void Update() {
        MoveInput.x = Input.GetAxisRaw("Horizontal");
        MoveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(KeyCode.Space)) {
            WeaponIndex += 1;

            if (WeaponIndex == Guns.Length) {
                WeaponIndex = 0;
            }

            SetWeapon(WeaponIndex);
        }
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

    private void SetWeapon(int Index) {
        GameObject Weapon = Instantiate(Guns[Index], WeaponPosition.position, transform.rotation);
        Weapon.GetComponent<Transform>().SetParent(transform);

        if (CurrentWeapon != null) {
            Destroy(CurrentWeapon);
        }

        CurrentWeapon = Weapon;
    }

    public void TakeWeapon(GameObject WeaponRef) {
        Array.Resize<GameObject>(ref Guns, Guns.Length + 1);

        Guns[Guns.Length - 1] = WeaponRef;

        if (CurrentWeapon == null) {
            SetWeapon(Guns.Length - 1);
        }
    }

    public void UseAmmo() {
        Ammo -= 1;
    }

    public void TakeAmmo(int Amount) {
        Ammo += Amount;
    }

    public void TakeDamage(int Damage) {
        if (!CanTakeDamage) return;

        Health -= Damage;

        if (Health <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeHealth(int ExtraHealth) {
        Health += ExtraHealth;
    }
}