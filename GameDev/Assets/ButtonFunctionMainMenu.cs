using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunctionMainMenu : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
