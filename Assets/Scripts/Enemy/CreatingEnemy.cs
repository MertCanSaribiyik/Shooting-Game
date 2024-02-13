using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreatingEnemy : MonoBehaviour {
    public GameObject[] enemyPrefabs;

    private float time;
    public float timeRange;

    [SerializeField] private float enemyEmergenceTime;

    private void Awake() {
        time = Time.time + 2f;
        enemyEmergenceTime += time;
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
        float zPos = Random.Range(transform.position.z - transform.localScale.z / 2, transform.position.z + transform.localScale.z / 2);

        int enemyTypeValue = 3;
        
        if(Time.time >= 3 * enemyEmergenceTime) 
            enemyTypeValue = 5;
        else if(Time.time >= enemyEmergenceTime) 
            enemyTypeValue = 4;

        int index = PossibiltyCreatingEnemies(enemyTypeValue);

        float yPos = enemyPrefabs[index].transform.position.y;
        Instantiate(enemyPrefabs[index], new Vector3(xPos, yPos, zPos), Quaternion.identity);
    }

    //Creating enemies in different possibilities : 
    private int PossibiltyCreatingEnemies(int maxValue) {
        int value = Random.Range(1, maxValue + 1);      //1 - maxValue

        if (value == 1 || value == 2 || value == 3) {
            return 0;       //NormalEnemy i.e EnemyPrefabs[0]
        }

        else if (value == 4) {
            return 1;       //DodgedEnemy i.e EnemyPrefabs[1]
        }

        else {
            return 2;       //FlyedEnemy i.e EnemyPrefabs[2]
        }
    }
}
