using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed;

    //Bullet movement : 
    private void Update() {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    //Bullet is destroyed : 
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }
    }

  
}
