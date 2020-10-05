using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour {

    public GameObject interactImage;
    public GameObject interactText;
    public Image fadeImage;
    public TextMeshProUGUI energyText;

    public Sprite keySprite;
    public Sprite interactSprite;

    private void Start() {
        SetUI(false, false);
    }

    public void FadeScreen(bool fadeOut) {
        StartCoroutine(Fade(fadeOut));
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

    public void SetUI(bool status, bool door) {
        interactImage.GetComponent<Image>().sprite = door ? keySprite : interactSprite;
        interactImage.SetActive(status);
        interactText.SetActive(status);
    }
}
