using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float speed;
    public float damage;

    //Enemy movement : 
    private void Update() {
        transform.Translate(0f, 0f, -speed * Time.deltaTime);
    }

    //Enemy and bullet are destroyed : 
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Bullet")) {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
