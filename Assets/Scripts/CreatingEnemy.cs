using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatingEnemy : MonoBehaviour {
    [SerializeField] private GameObject enemyPrefab;

    private float time;
    [SerializeField] private float timeRange;

    private void Awake() {
        time = Time.time + 2f;
    }

    private void Update() {
        if(Time.time >= time) {
            Create();
            time = Time.time + timeRange;
        }
    }

    //Creating of the enemy in random position in enemy area : 
    private void Create() {
        float xPos = Random.Range(transform.position.x - transform.localScale.x / 2, transform.position.x + transform.localScale.x / 2);
        float yPos = Random.Range(enemyPrefab.transform.position.y, enemyPrefab.transform.position.y + 2f);
        float zPos = Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2);

        Instantiate(enemyPrefab, new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }
}
