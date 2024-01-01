using UnityEngine;

public class WaveManager : MonoBehaviour {
    public GameObject[] Waves;
    public int[] TimeBetweenWaves;

    private int currentWave = 0;

    private void Start() {
        if (Waves.Length < 1) return;

        Waves[currentWave].SetActive(true);

        if (Waves.Length > 1) {
            Invoke("StartWave", TimeBetweenWaves[currentWave]);
        }
    }

    private void StartWave() {
        currentWave += 1;

        if (currentWave != Waves.Length) {
            Waves[currentWave].SetActive(true);

            if (currentWave != TimeBetweenWaves.Length) {
                Invoke("StartWave", TimeBetweenWaves[currentWave]);
            }
        }
    }
}