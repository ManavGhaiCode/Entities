using UnityEngine;

public class MeleeEnemySpawner : MonoBehaviour {
    public GameObject MeleeEnemyPerfab;
    public float LifeTime;
    public float TimeBetweenSpawns;

    private float TimeToSpawn;

    private void Start() {
        TimeToSpawn = Time.time + TimeBetweenSpawns;
        Destroy(gameObject, LifeTime);
    }

    private void Update() {
        if (TimeToSpawn <= Time.time) {
            Instantiate(MeleeEnemyPerfab, transform.position, transform.rotation);
            TimeToSpawn += TimeBetweenSpawns;
        }
    }
}