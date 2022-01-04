using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int score = 0;
    public static string playerName = "Player";

    void Awake()
    {
    }

    public static void setScore(int myscore) {
        score = myscore;
    }
}


