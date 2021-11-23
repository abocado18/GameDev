using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathbox : MonoBehaviour
{
    public float deathHeight = -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= deathHeight)
        {
            ScoreScript.scoreValue = 0;
            Scene currentScene = SceneManager.GetActiveScene();
            string name = currentScene.name;
            SceneManager.LoadScene(name);
        }
    }
}
