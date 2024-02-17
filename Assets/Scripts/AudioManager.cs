using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance { get; private set; }

    private AudioSource audioSource;

    [SerializeField] private AudioClip selectedSoundEffect;
    [SerializeField] private AudioClip enteredSoundEffect;
    
    private void Awake() {
        //Initial value assignment for the instance variable :
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }

        //Initial value assigment for the audioSource : 
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShotSound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

    public void SelectedSoundEffect() {
        audioSource.PlayOneShot(selectedSoundEffect);
    }

    public void EnteredSoundEffect() {
        audioSource.PlayOneShot(enteredSoundEffect);
    }
}
