using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	public string sceneName;

	public string uiText;
	public int prerequisite = -1;

	private bool playerHere = false;

	private PlayerUI playerUI;
	private Life life;

    private void Awake() {
		life = FindObjectOfType<Life>();
		playerUI = FindObjectOfType<PlayerUI>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			playerHere = true;
			if(playerUI) {
				playerUI.SetUI(true, true, uiText);
			}
		}
	}

    private void OnTriggerExit2D(Collider2D col) {
		if(col.CompareTag("Player")) {
			playerHere = false;
			playerUI.SetUI(false, true, "");
		}
	}

    private void Update() {
		if(Input.GetKeyDown(KeyCode.Space) && playerHere) {
			if(prerequisite >= 0 && PlayerData.Interactions[prerequisite] <= 0) {
				playerUI.Notify();
			}
			else {
				AudioManager.audioManager.PlaySound("Door");
				life.ChangingScene(sceneName);
			}			
		}
    }
}
