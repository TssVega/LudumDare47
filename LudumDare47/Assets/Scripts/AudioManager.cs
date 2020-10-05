using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

    public static AudioManager audioManager;
    public Sound[] sounds;

    private void Awake() {
        audioManager = this;
    }
    private void Start() {
        for(int i = 0; i < sounds.Length; i++) {
            GameObject _go = new GameObject("Sound_" + i + "_" + sounds[i].audioName);
            _go.transform.SetParent(this.transform);
            sounds[i].SetSource(_go.AddComponent<AudioSource>());
        }
        PlaySound("Soundtrack");
    }
    public void PlaySound(string _name) {
        if(!PlayerData.mute) {
            for(int i = 0; i < sounds.Length; i++) {
                if(sounds[i].audioName == _name) {
                    sounds[i].Play();
                }
            }
        }
    }
    public void Mute() {
        PlayerData.mute = !PlayerData.mute;
    }
    public void StopSound(string _name) {
        for(int i = 0; i < sounds.Length; i++) {
            if(sounds[i].audioName == _name) {
                sounds[i].Stop();
            }
        }
    }
}
