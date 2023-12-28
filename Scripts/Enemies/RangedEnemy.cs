using System;
using UnityEngine;

public class RangedEnemy : Enemy {
    public float StopDistance = 5f;
    public float TimeBetweenAttacks;

    public EnemyGun Gun;

    private float TimeToShoot;

    private void Start() {
        base.Start();
        TimeToShoot = Time.time + TimeBetweenAttacks;
        Gun.Damage = Damage;
    }

    private void FixedUpdate() {
        if (player == null) { return; }

        Vector2 LookDir = transform.position - player.position;
        float angle = Mathf.Atan2(LookDir.y, LookDir.x) * Mathf.Rad2Deg + 90;

        rb.rotation = angle;

        if (Vector2.Distance(transform.position, player.position) > StopDistance) {
            Vector2 MoveDirection = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
            rb.MovePosition(MoveDirection);
        } else {
            rb.velocity = Vector2.zero;

            if (TimeToShoot <= Time.time) {
                Gun.Shoot();
                TimeToShoot = Time.time + TimeBetweenAttacks;
            }
        }
    }
}