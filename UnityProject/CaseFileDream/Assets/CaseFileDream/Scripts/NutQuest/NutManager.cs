using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NutManager : MonoBehaviour
{
    public static NutManager instance;

    public int nuts;
    public TextMeshProUGUI nutDisplay;

    // Start is called before the first frame update
    private void Awake()
    {
        if (!instance)
        {
            instance = this;

        }

    }


    private void ONGUI()
    {
        nutDisplay.text = nuts.ToString();

    }

    public void ChangeNuts(int amount)
    {
        nuts += amount;
        nutDisplay.text = nuts.ToString();

    }
    
}
