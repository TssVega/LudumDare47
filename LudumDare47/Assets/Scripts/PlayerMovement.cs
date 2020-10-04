using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float MoveSpeed {
		get; set;
	} = 7f;

    private Vector2 movementVector;
    private bool lastMovedRight = true;

    private void Start() {
        movementVector = Vector2.zero;
    }

    private void Update() {
        GetInput();
        Move();
    }

    private void GetInput() {
        movementVector = Vector2.zero;
        if(Input.GetAxis("Horizontal") != 0) {
            lastMovedRight = Input.GetAxis("Horizontal") > 0;
            if(lastMovedRight) {
                transform.localScale = Vector3.one;
            }
            else {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            movementVector = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }
    }

    private void Move() {
        transform.Translate(movementVector * MoveSpeed * Time.deltaTime);
    }
}
