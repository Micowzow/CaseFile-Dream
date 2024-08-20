using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class GameData
{
    public int essenceCount;

    public Vector3 playerPosition;


    // the values defined in this constructor will be the default values
    //the game starts with when theres no data to load
    public GameData()
    {
        this.essenceCount = 0;
        playerPosition = Vector3.zero;
    }
    
}
