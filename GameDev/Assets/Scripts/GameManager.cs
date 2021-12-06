using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int score = 0;

    void Awake()
    {
    }

    public static void setScore(int myscore) {
        score = myscore;
    }
}


