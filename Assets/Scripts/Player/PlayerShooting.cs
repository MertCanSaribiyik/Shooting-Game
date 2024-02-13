using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip clip;

    private void Update() {
        if(Input.GetMouseButtonDown(0) && !gameManager.gameIsPaused) {
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(bulletPrefab, transform.position + new Vector3(0.35f, 1f, 1f), transform.rotation);
        AudioManager.PlayOneShotSound(clip);
    }
}
