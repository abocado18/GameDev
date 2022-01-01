using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctionMainMenu : MonoBehaviour
{
    public Button startButton, exitButton;
    public GameObject levelEditor;
    void Start()
    {
        if(InfoGoalBoard.showLevelSelector == true)
        {
            startButton.enabled = false;
            exitButton.enabled = false;
            levelEditor.SetActive(true);
            InfoGoalBoard.showLevelSelector = false;
        }
        else
        {
            startButton.enabled = true;
            exitButton.enabled = true;
            levelEditor.SetActive(false);
        }
        
    }

    public void StartButton()
    {
        startButton.enabled = false;
        exitButton.enabled = false;
        levelEditor.SetActive(true);
        //SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        startButton.enabled = true;
        exitButton.enabled = true;
        levelEditor.SetActive(false);
    }
}
