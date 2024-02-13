using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
    private Slider slider;

    private void Awake() {
        slider = GetComponent<Slider>();  
        slider.value = Player.Instance.MaxHealth;   
    }

    public Slider Slider { get { return slider; } }
}
