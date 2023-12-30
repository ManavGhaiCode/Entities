using UnityEngine;

public class CameraController : MonoBehaviour {
    public float speed = 0.125f;

    private Transform player;
    private Vector2 Target;

    private void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate() {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Target = ( (Vector2)player.position + ( MousePosition * .3f ) ) / 2f;

        Vector2 TargetPosition = Vector2.Lerp(transform.position, Target, speed);

        transform.position = new Vector3 (TargetPosition.x, TargetPosition.y, -10) ;
    }
}