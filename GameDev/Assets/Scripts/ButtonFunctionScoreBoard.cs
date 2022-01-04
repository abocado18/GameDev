using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonFunctionScoreBoard : MonoBehaviour
{
    public void RepeatButton()
    {
        
      
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void MainMenuButton()
    {
        ScoreScript.scoreValue = 0;
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
    }
    
}
