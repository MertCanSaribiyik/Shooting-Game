using UnityEngine;

public class DodgedEnemy : MonoBehaviour {
    [SerializeField] private Color color;

    [SerializeField] private EnemySword enemySword;
    [SerializeField] private float dodgeForce;
    private Transform firstPoint, lastPoint;

    [SerializeField] private int maxDodge;
    private int dodgeCount;
   
    private void Awake() {
        GetComponent<MeshRenderer>().material.color = color;
        dodgeCount = 0;

        firstPoint = GameObject.FindWithTag("FirstPoint").transform;
        lastPoint = GameObject.FindWithTag("LastPoint").transform;
    }

    private void Update() {
        if(enemySword.dogde && dodgeCount < maxDodge) {
            Dodged();
            dodgeCount++;
        }
    }

    private void Dodged() {
        float firstXPos = firstPoint.position.x;
        float lastXPos = lastPoint.position.x;
        float dodgeForce = this.dodgeForce;

        //If the enemy going off the map to the left during dodge the dodge direction is set to the right : 
        if (transform.position.x - dodgeForce <= firstXPos) {
            dodgeForce *= 1;
        }

        //If the enemy going off the map to the right during dodge the dodge direction is set to the left : 
        else if (transform.position.x + dodgeForce >= lastXPos) {
            dodgeForce *= -1;
        }

        //If the enemy is already on the map during dodge, the dodge direction is randomized : 
        else {
            int value = Random.Range(0, 2);     //0 - 1
            dodgeForce = (value == 0) ? dodgeForce *= 1 : dodgeForce *= -1;  
        }

        transform.Translate(dodgeForce, 0f, 0f);
    }
}