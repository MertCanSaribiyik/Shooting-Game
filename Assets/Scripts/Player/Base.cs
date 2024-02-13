using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Enemy")) {
            Player.Instance.CurrentHealth -= other.gameObject.GetComponent<Enemy>().Damage;
            Destroy(other.gameObject);
        }    
    }

}
