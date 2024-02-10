using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private float startingEnemySpeed;
    private GameObject[] enemies;

    private float sceneStartTime, time;
    [SerializeField] private float difficultyStartTime;
    [SerializeField] private float increase;

    //Variables for the pause game menu : 
    public bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private TMPro.TextMeshProUGUI resumeBtnTxt;

    [SerializeField] private HealthBar healthBar;
    private bool isDied;

    private void Awake() {
        //Initial value assignment for enemies : 
        enemies = spawnArea.GetComponent<CreatingEnemy>().enemyPrefabs;

        foreach(GameObject enemy in enemies) {
            enemy.GetComponent<Enemy>().speed = startingEnemySpeed;
        }

        sceneStartTime = Time.time;
        time = Time.time + 1f;

        //Onitial value assignment for Pause Menu : 
        pauseMenu.SetActive(false);
        gameIsPaused = false;

        isDied = false;
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

        Died();
        GamePause();
    }

    //Over time, the speed of the character and enemies increases, and the spawn time of enemies decreases :
    private void IncreasedDifficult() {
        player.GetComponent<Player>().speed += increase * 2;

        if (spawnArea.GetComponent<CreatingEnemy>().timeRange >= 0.35f) 
            spawnArea.GetComponent<CreatingEnemy>().timeRange -= increase / 5;

        foreach (GameObject enemy in enemies) {
            enemy.GetComponent<Enemy>().speed += increase;
        }
    }

    private void GamePause() {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            if(gameIsPaused) {
                Resume();
            }

            else {
                Pause();
            }
        }
    }

    public void Resume() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameIsPaused = false;

        if(healthBar.Finished()) 
            SceneOperations.ReloadScene();
        
    }

    private void Pause() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameIsPaused = true;

        if (healthBar.Finished()) {
            resumeBtnTxt.fontSize = 100;
            resumeBtnTxt.text = "PLAY AGAIN";
        }

        else {
            resumeBtnTxt.fontSize = 120;
            resumeBtnTxt.text = "RESUME";
        }
    }

    private void Died() {
        if (healthBar.Finished() && !isDied) {
            Pause();
            isDied = true;
        }
    }

}
