using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class GameData
{
    public int essenceCount;

    public Vector3 playerPosition;

    public bool hasBubble;


    // the values defined in this constructor will be the default values
    //the game starts with when theres no data to load
    public GameData()
    {
        //AMOUNT OF ESSENCE
        this.essenceCount = 0;

        //PLAYER POSITION
        //playerPosition = Vector3.zero;

        this.hasBubble = false;
    }
    
}
