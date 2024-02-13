using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Slider healthBarSlider;
    [SerializeField] private TMPro.TextMeshProUGUI scoreTxt;
    private bool isDead;

    private void Awake() {
        isDead = false;
    }

    private void Update() {
        if(Player.Instance.CurrentHealth <= 0 && !isDead) {
            gameManager.Pause();
            isDead = true;
        }

        healthBarSlider.value = Player.Instance.CurrentHealth;
        scoreTxt.text = Player.Instance.Score.ToString();
    }
}
