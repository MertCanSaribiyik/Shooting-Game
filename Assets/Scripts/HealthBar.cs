using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    private Slider slider;
    [SerializeField] private float maxHealth;

    private void Awake() {
        slider = GetComponent<Slider>();  
        slider.value = maxHealth;   
    }

    public void TakeDamage(float damage) {
        slider.value -= damage;
    }

    public bool Finished() {
        if (slider.value <= 0)
            return true;

        return false;
    }

    public float getHealth() {
        return slider.value;
    }
}
