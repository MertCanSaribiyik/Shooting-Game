using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DodgedEnemy : MonoBehaviour {
    [SerializeField] private GameObject enemySword;
    [SerializeField] private float dodgeForce;
    private Transform firstPoint, lastPoint;
    private bool isDogded;
   
    private void Awake() {
        isDogded = false;

        firstPoint = GameObject.FindWithTag("FirstPoint").transform;
        lastPoint = GameObject.FindWithTag("LastPoint").transform;
    }

    private void Update() {
        if(enemySword.GetComponent<EnemySword>().dogde && !isDogded) {
            Dodged();
            isDogded = true;
        }
    }

    private void Dodged() {
        float firstXPos = firstPoint.position.x;
        float lastXPos = lastPoint.position.x;

        //For the enemy not to leave the map during the dodge : 
        if (transform.position.x - dodgeForce <= firstXPos) {
            transform.Translate(dodgeForce, 0f, 0f);
            return;
        }

        else if(transform.position.x + dodgeForce >= lastXPos) {
            transform.Translate(-dodgeForce, 0f, 0f);
            return;
        }

        //If the enemy is already on the map during the dodge : 
        int value = Random.Range(0, 2);     //0 - 1

        if(value == 0) {
            transform.Translate(dodgeForce, 0f, 0f);
        }

        else {
            transform.Translate(-dodgeForce, 0f, 0f);
        }
    }
}