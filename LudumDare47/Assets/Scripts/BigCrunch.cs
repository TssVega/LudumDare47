using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BigCrunch : MonoBehaviour {

	private ParticleSystem particles;

    private void Awake() {
        particles = GetComponent<ParticleSystem>();
    }

    private void Start() {        
        StartCoroutine(ParticleTimer());
	}

    private IEnumerator ParticleTimer() {
        yield return new WaitForSeconds(1);
        particles.Play();
        yield return new WaitForSeconds(7);
        particles.Stop();
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync("BigBang");
    }
}
