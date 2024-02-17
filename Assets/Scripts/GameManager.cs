using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    //Variables for objects to be difficulty :
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private float startingEnemySpeed;
    [SerializeField] private Enemy[] enemies;

    //Variables for difficulty : 
    private float sceneStartTime, time;
    [SerializeField] private float difficultyStartTime;
    [SerializeField] private float increase;

    //Variables for the pause game menu : 
    public bool gameIsPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject resumeBtn;
    [SerializeField] private TMPro.TextMeshProUGUI resumeBtnTxt;

    private void Awake() {
        //Initial vale assigment for enemies : 
        foreach (Enemy enemy in enemies) 
            enemy.Speed = startingEnemySpeed;

        sceneStartTime = Time.time;
        time = Time.time + 1f;

        //Initial value assignment for Pause Menu : 
        pauseMenu.SetActive(false);
        gameIsPaused = false;

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

        GamePause();
    }

    //Over time, the speed of the character and enemies increases, and the spawn time of enemies decreases :
    private void IncreasedDifficult() {
        Player.Instance.Speed += increase;

        if (spawnArea.GetComponent<CreatingEnemy>().timeRange >= 0.35f) 
            spawnArea.GetComponent<CreatingEnemy>().timeRange -= increase / 5;
        
         foreach (Enemy enemy in enemies) 
            enemy.Speed += increase;
    }

    private void GamePause() {
        if(Input.GetButtonDown("Cancel")) {
            if(gameIsPaused) 
                Resume();
            else 
                Pause();
        }
    }

    public void Resume() {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gameIsPaused = false;

        EventSystem.current.SetSelectedGameObject(null);

        if (Player.Instance.CurrentHealth <= 0f) 
            SceneOperations.ReloadScene();
    }

    public void Pause() {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gameIsPaused = true;

        EventSystem.current.SetSelectedGameObject(resumeBtn);


        if (Player.Instance.CurrentHealth <= 0f) {
            resumeBtnTxt.fontSize = 100;
            resumeBtnTxt.text = "PLAY AGAIN";
        }

        else {
            resumeBtnTxt.fontSize = 120;
            resumeBtnTxt.text = "RESUME";
        }
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneOperations.PreviosScene();
    }
}
