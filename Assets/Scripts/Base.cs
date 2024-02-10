using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour {

    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Enemy enemy;

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            healthBar.TakeDamage(enemy.damage);
            Destroy(other.gameObject);
        }    
    }

}
