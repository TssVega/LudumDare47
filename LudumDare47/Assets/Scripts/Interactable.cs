using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour {

    private bool playerHere = false;
	public int index;
	public string description;
	private bool interacted = false;

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
				playerUI.SetUI(true, false, description);
			}
		}
	}

	private void OnTriggerExit2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			playerHere = false;
			playerUI.SetUI(false, false, "");
		}
	}

	private void Update() {
		if(Input.GetKeyDown(KeyCode.Space) && playerHere) {
			Interact();
		}
	}

	private void Interact() {
		if(!interacted) {
			AudioManager.audioManager.PlaySound("Interact");
			life.Interact(index);
		}
		StartCoroutine(InteractCountdown());
	}

	private IEnumerator InteractCountdown() {
		interacted = true;
		yield return new WaitForSeconds(1.5f);
		interacted = false;
	}
}
