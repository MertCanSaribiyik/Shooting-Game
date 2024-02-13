using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {
    public bool Dodge { get; set; }

    private void Awake() {
        Dodge = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullet")) {
            Dodge = true;
        }
    }
}
