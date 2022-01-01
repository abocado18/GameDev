using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctionsGoalBoard : MonoBehaviour
{
    
   public void Repeat()
    {
        string name = SceneManager.GetActiveScene().name;
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void ShowLevelSelect()
    {
        InfoGoalBoard.showLevelSelector = true;
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("MenuScene");    
    }
}

public static class InfoGoalBoard
{
    public static bool showLevelSelector { get; set; }
}
