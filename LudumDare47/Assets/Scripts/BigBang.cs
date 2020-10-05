using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BigBang : MonoBehaviour {

    private ParticleSystem particles;

    private void Awake() {
        particles = GetComponent<ParticleSystem>();
    }

    private void Start() {
        StartCoroutine(ParticleTimer());
    }

    private IEnumerator ParticleTimer() {
        yield return new WaitForSeconds(0.5f);
        particles.Play();
        yield return new WaitForSeconds(5);
        SceneManager.LoadSceneAsync("Hospital");
    }
}
