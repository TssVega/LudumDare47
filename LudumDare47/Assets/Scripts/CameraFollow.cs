using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public bool follow = false;
    public Transform playerTransform;
    private Camera cam;
    public float[] cameraBoundsX;

    private void Awake() {
        cam = GetComponent<Camera>();
    }

    private void Update() {
        if(follow && playerTransform) {
            float cameraX = Mathf.Clamp(playerTransform.position.x, cameraBoundsX[0], cameraBoundsX[1]);
            cam.transform.position = new Vector3(cameraX, transform.position.y, -10f);
        }        
    }
}
