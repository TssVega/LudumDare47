using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float MoveSpeed {
		get; set;
	} = 7f;

    public float[] currentLevelXBounds;

    private Vector2 movementVector;
    private bool lastMovedRight = true;
    private Life life;
    private bool moving = false;
    private bool movingSoundsOn = false;
    private Coroutine movingSounds;

    private void Awake() {
        life = FindObjectOfType<Life>();
    }

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
            Debug.Log(Input.GetAxis("Horizontal"));
            if(Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f) {
                moving = true;
            }
            else {
                moving = false;
            }
            lastMovedRight = Input.GetAxis("Horizontal") > 0;
            if(lastMovedRight) {
                transform.localScale = Vector3.one;
            }
            else {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            movementVector = new Vector2(Input.GetAxis("Horizontal"), 0f);
        }
        else {
            moving = false;
        }
        if(Input.GetKeyDown(KeyCode.M)) {
            AudioManager.audioManager.Mute();
        }
    }

    private void Move() {
        if(!life.canMove) {
            return;
        }
        if(!movingSoundsOn && moving) {
            movingSoundsOn = true;
            movingSounds = StartCoroutine(MovingSounds());
        }
        transform.Translate(movementVector * MoveSpeed * Time.deltaTime);
        if(transform.position.x < currentLevelXBounds[0]) {
            transform.position = new Vector3(currentLevelXBounds[0], transform.position.y, 0f);
        }
        if(transform.position.x > currentLevelXBounds[1]) {
            transform.position = new Vector3(currentLevelXBounds[1], transform.position.y, 0f);
        }
    }

    private IEnumerator MovingSounds() {
        AudioManager.audioManager.PlaySound("Walk");
        yield return new WaitForSeconds(0.2f);
        if(gameObject.activeInHierarchy && moving) {
            movingSounds = StartCoroutine(MovingSounds());
        }
        else {            
            movingSoundsOn = false;
            StopCoroutine(movingSounds);
        }
    }
}
