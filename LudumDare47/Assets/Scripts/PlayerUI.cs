using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerUI : MonoBehaviour {

    public GameObject interactImage;
    public GameObject interactText;
    public TextMeshProUGUI interactName;
    public Image fadeImage;
    public TextMeshProUGUI energyText;

    public Sprite keySprite;
    public Sprite interactSprite;

    public GameObject deathPanel;
    public TextMeshProUGUI ageText;
    public TextMeshProUGUI reasonText;
    public GameObject notificationText;

    private bool deathUIOpen = false;

    private void Start() {
        SetUI(false, false, "");
        CloseDeathUI();
    }

    private void Update() {
        if(deathUIOpen && Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadSceneAsync("BigCrunch");
        }
    }

    public void FadeScreen(bool fadeOut) {
        StartCoroutine(Fade(fadeOut));
    }

    public void Notify() {
        StartCoroutine(NotificationUI());
    }

    private IEnumerator NotificationUI() {
        notificationText.SetActive(true);
        yield return new WaitForSeconds(3f);
        notificationText.SetActive(false);
    }

    public void OpenDeathUI(string age, string reason) {
        deathUIOpen = true;
        deathPanel.SetActive(true);
        ageText.text = age;
        reasonText.text = reason;
    }

    public void CloseDeathUI() {
        deathUIOpen = false;
        deathPanel.SetActive(false);
    }

    private IEnumerator Fade(bool fadeOut) {
        float currentAlpha;
        if(fadeOut) {
            currentAlpha = 0f;
        }
        else {
            currentAlpha = 1f;
        }
        if(fadeOut) {
            while(currentAlpha < 1) {
                fadeImage.color = new Color(0, 0, 0, currentAlpha += 0.02f);
                yield return null;
            }
        }
        else {
            while(currentAlpha > 0) {
                fadeImage.color = new Color(0, 0, 0, currentAlpha -= 0.02f);
                yield return null;
            }
        }
    }

    public void UpdateEnergy() {
        energyText.text = PlayerData.InteractionsLeft.ToString();
    }

    public void SetUI(bool status, bool door, string name) {
        interactImage.GetComponent<Image>().sprite = door ? keySprite : interactSprite;
        interactName.text = name;
        interactImage.SetActive(status);
        interactText.SetActive(status);
    }
}
