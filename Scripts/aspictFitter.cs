using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class aspictFitter : MonoBehaviour {
    public float sceneWidth = 21.5f;

    private Camera cam;

    void Start() {
        cam = GetComponent<Camera>();
    }

    void Update() {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        cam.orthographicSize = desiredHalfHeight;
    }
}