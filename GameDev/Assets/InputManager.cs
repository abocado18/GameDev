using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public void Text_Changed(string playername){
        GameManager.playerName = playername;
        Debug.Log(GameManager.playerName);
    }
}
