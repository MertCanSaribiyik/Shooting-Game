using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour {

    [SerializeField] private GameObject panel_1;
    [SerializeField] private GameObject panel_2;
    private bool gameStarting;

    [SerializeField] private GameObject panel1FirstBtn;
    [SerializeField] private GameObject panel2FirstBtn;

    [SerializeField] private TMPro.TextMeshProUGUI highScoreTxt;

    private void Awake() {
        panel_1.SetActive(true);
        panel_2.SetActive(false);
        gameStarting = false;

        EventSystem.current.SetSelectedGameObject(panel1FirstBtn);

        highScoreTxt.text = $"Your Highscore : {PlayerPrefs.GetInt("score")}";
    }


    public void PlayBtn() {
        if(gameStarting) {
            SceneOperations.NextScene();
            return;
        }

        EventSystem.current.SetSelectedGameObject(panel2FirstBtn);

        panel_1.SetActive(false);
        panel_2.SetActive(true);
        gameStarting = true;
    }

    public void BackBtn() {
        panel_1.SetActive(true);
        panel_2.SetActive(false);
        gameStarting = false;

        EventSystem.current.SetSelectedGameObject(panel1FirstBtn);
    }

    public void QuitGameBtn() {
        Application.Quit();
    }

}
