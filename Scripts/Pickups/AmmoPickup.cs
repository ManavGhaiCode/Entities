using UnityEngine;

public class AmmoPickup : MonoBehaviour {
    public int AmmoAmount;

    private void OnTriggerEnter2D(Collider2D hitInfo) {
        Player player = hitInfo.GetComponent<Player>();

        if (player != null) {
            player.TakeAmmo(AmmoAmount);
            Destroy(gameObject);
        }
    }
}