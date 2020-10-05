using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour {	

	public Sprite[] ageSprites;
	public SpriteRenderer sky;
	public Light2D sun;
	public GameObject[] buildings;
	public GameObject lightPoles;
	public Color daySkyColor;
	public Color nightSkyColor;

	private readonly float dayLightIntensity = 1f;
	private PlayerMovement player;
	private SpriteRenderer playerSprite;
	private PlayerUI playerUI;
	public bool canMove;
	public Transform[] exitPoints;	// 0 home, 1 school, 2 workplace

    private void Awake() {
		playerUI = FindObjectOfType<PlayerUI>();
		player = FindObjectOfType<PlayerMovement>();
		playerSprite = player.GetComponent<SpriteRenderer>();
    }

    private void Start() {
		playerUI.UpdateEnergy();
		canMove = true;
		playerUI.FadeScreen(false);
		SetAgeSprite();
		ChangeToDay();
		CheckStartPoint();
	}

	public void ResetGame() {
		playerUI.UpdateEnergy();
		canMove = true;
		playerUI.FadeScreen(false);
		SetAgeSprite();
		ChangeToDay();
		CheckStartPoint();
	}

	private void CheckStartPoint() {
		if(SceneManager.GetActiveScene().name == "City" && PlayerData.exitPointName == "City") {
			if(PlayerData.lastPlace == "Home") {
				player.transform.position = exitPoints[0].position;
			}
			if(PlayerData.lastPlace == "School") {
				player.transform.position = exitPoints[1].position;
			}
			if(PlayerData.lastPlace == "Workplace") {
				player.transform.position = exitPoints[2].position;
			}
		}
	}

	private void SetAgeSprite() {
		if(PlayerData.PAge == Age.Child) {
			playerSprite.sprite = ageSprites[0];
		}
		if(PlayerData.PAge == Age.Young) {
			playerSprite.sprite = ageSprites[0];
		}
		if(PlayerData.PAge == Age.Adult) {
			playerSprite.sprite = ageSprites[1];
		}
		if(PlayerData.PAge == Age.Old) {
			playerSprite.sprite = ageSprites[2];
		}
	}
	/*
    private bool DetermineWealthOnBirth() {
		return Random.Range(0, 11) >= 9;
	}
	*/
	public void Interact(int index) {
		StartCoroutine(Interaction(index));
	}

	private IEnumerator Interaction(int index) {
		canMove = false;
		playerUI.FadeScreen(true);
		yield return new WaitForSeconds(1f);
		PlayerData.Interact(index);
		playerUI.UpdateEnergy();
		HealthData health = PlayerData.CheckHealth();
		CheckHealth(health);
		SetAgeSprite();
		playerUI.FadeScreen(false);
		canMove = true;
		yield return new WaitForSeconds(1f);		
	}

	private void CheckHealth(HealthData health) {
		if(health.isDead) {
			PlayerData.Die();
			playerUI.OpenDeathUI($"Age: {health.age}", $"Cause of death: {health.cause}");
		}
	}

	public void ChangingScene(string sceneName) {
		PlayerData.lastPlace = SceneManager.GetActiveScene().name;
		PlayerData.exitPointName = sceneName;
		StartCoroutine(Suspense(sceneName));
	}

	private IEnumerator Suspense(string sceneName) {
		canMove = false;
		playerUI.FadeScreen(true);
		yield return new WaitForSeconds(1f);
		LoadSceneAsynchronously(sceneName);
	}

	private void ChangeToDay() {
		if(sun) {
			sun.intensity = dayLightIntensity;
		}
		if(sky) {
			sky.color = daySkyColor;
		}		
	}

	private void LoadSceneAsynchronously(string sceneName) {
		SceneManager.LoadSceneAsync(sceneName);
	}
}
