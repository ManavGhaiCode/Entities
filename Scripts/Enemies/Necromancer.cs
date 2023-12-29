using UnityEngine;

public class Necromancer : Enemy {
    public GameObject[] SummonEnemies;
    public GameObject bulletPerfab;
    public Transform SummonPoint;

    public float TimeBetweenSummons = 2f;
    public float TimeBetweenShoots = 5f;

    private Vector2 Target;

    private float TimeToSummon;
    
    private void Start() {
        base.Start();
        Target.x = Random.Range(-(player.position.x - 7), (player.position.x - 7));
        Target.y = Random.Range(-(player.position.y - 7), (player.position.y - 7));

        TimeToSummon = Time.time + TimeBetweenSummons;
    }

    private void FixedUpdate() {
        if (TimeToSummon <= Time.time) {
            Summon();
            TimeToSummon = Time.time + TimeBetweenSummons;

            return;
        }

        // if ()

        rb.MovePosition(Vector2.MoveTowards(transform.position, Target, speed * Time.fixedDeltaTime));

        if (Vector2.Distance(transform.position, Target) < 0.5f) {
            Target.x = Random.Range(-(player.position.x - 7), (player.position.x - 7));
            Target.y = Random.Range(-(player.position.y - 7), (player.position.y - 7));
        }
    }

    private void Summon() {
        GameObject summonObject = SummonEnemies[Random.Range(0, SummonEnemies.Length)];
        Instantiate(summonObject, SummonPoint.position, SummonPoint.rotation);
    }
}