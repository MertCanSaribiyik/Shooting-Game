using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnArea;

    private float sceneStartTime, time;
    [SerializeField] private float difficultyStartTime;
    [SerializeField] private float increase;

    private void Awake() {
        sceneStartTime = Time.time;
        time = Time.time + 1f;
    }

    private void Update() {
        //Every one second : 
        if (Time.time >= time) {
            time = Time.time + 1f;

            //Difficulty increases after a certain period of time : 
            if (Time.time >= sceneStartTime + difficultyStartTime) {
                IncreasedDifficult();
            }
        }
    }

    //Over time, the speed of the character and enemies increases, and the spawn time of enemies decreases :
    private void IncreasedDifficult() {
        player.GetComponent<Player>().speed += increase * 2;

        if (spawnArea.GetComponent<CreatingEnemy>().timeRange >= 0.35f) 
            spawnArea.GetComponent<CreatingEnemy>().timeRange -= increase / 5;

        GameObject[] enemies = spawnArea.GetComponent<CreatingEnemy>().enemyPrefabs;
        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Enemy>().speed += increase;
        }
    }

}
