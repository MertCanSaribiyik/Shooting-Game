using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed;

    //Bullet movement : 
    private void Update() {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    //Enemy and bullet are destroyed : 
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Wall")) {
            Destroy(gameObject);
        }

        else if(collision.gameObject.CompareTag("Enemy")) {
            Player.Instance.Score += collision.gameObject.GetComponent<Enemy>().Score;
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

}
