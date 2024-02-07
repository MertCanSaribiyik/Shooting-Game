using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySword : MonoBehaviour {
    public bool dogde;

    private void Awake() {
        dogde = false;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bullet") && !dogde) {
            dogde = true;
        }
    }
}
