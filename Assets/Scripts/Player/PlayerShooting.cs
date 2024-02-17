using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private AudioClip clip;

    //Variables for animation : 
    [SerializeField] private Animator animator;
    [SerializeField] private string shootingAnim;

    private void Update() {
        if(Input.GetButtonDown("Fire1") && !gameManager.gameIsPaused) {
            animator.SetTrigger(shootingAnim);
            Shoot();
        }
    }

    private void Shoot() {
        Instantiate(bulletPrefab, transform.position + new Vector3(0.35f, 1f, 1f), transform.rotation);
        AudioManager.Instance.PlayOneShotSound(clip);
    }
}
