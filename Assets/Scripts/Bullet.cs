using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    private float time;
    [SerializeField] private float timeRange;

    [SerializeField] private float speed;

    private void Start() {
        time = Time.time + timeRange;
    }

    //Bullet movement and destroyed after a while : 
    private void Update() {
        transform.Translate(0, 0, speed * Time.deltaTime);

        if(Time.time > time) {
            Destroy(gameObject);
        }
    }

    //The destroyed bullet if it collision a wall : 
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }
    }

}
