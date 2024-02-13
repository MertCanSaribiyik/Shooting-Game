using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioSource audioSource;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlayOneShotSound(AudioClip clip) {
        audioSource.PlayOneShot(clip);
    }

}
