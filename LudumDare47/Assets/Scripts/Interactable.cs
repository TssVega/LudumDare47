using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    private bool playerHere = false;
	public int index;
	public string description;
	private bool interacted = false;

	// Hobby indexes
	// 0: ipad
	// 1: toys
	// 2: biking
	// 3: tv

	private PlayerUI playerUI;
	private Life life;

	private void Awake() {
		life = FindObjectOfType<Life>();
		playerUI = FindObjectOfType<PlayerUI>();
	}

    private void Start() {
		interacted = false;
    }

    private void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			playerHere = true;
			if(playerUI) {
				playerUI.SetUI(true, false);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			playerHere = false;
			playerUI.SetUI(false, false);
		}
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Space) && playerHere) {
			Interact();
		}
	}

	private void Interact() {		
		if(!interacted) {
			life.Interact(index);
		}
		interacted = true;
	}
}
