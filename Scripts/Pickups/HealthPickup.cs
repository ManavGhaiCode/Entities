using UnityEngine;

public class HealthPickup : MonoBehaviour {
    public int ExtraHealth = 1;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Player player = hitInfo.GetComponent<Player>();

        if (player != null) {
            player.TakeHealth(ExtraHealth);
            Destroy(gameObject);
        }
    }
}