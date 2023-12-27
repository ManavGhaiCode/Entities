using UnityEngine;

public class Bullet : MonoBehaviour {
    public int Damage;
    public float lifespan;

    private void Start() {
        Destroy(gameObject, lifespan);
    }
}