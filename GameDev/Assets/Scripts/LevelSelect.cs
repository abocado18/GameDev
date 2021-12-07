using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    public string level;

    public void Select()
    {
        SceneManager.LoadScene(level);
    }
}
