using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EssenceManager : MonoBehaviour
{
    public static EssenceManager instance;

    public int essences;
    public TextMeshProUGUI essenceDisplay;

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
        essenceDisplay.text = essences.ToString();

    }

    public void ChangeEssences(int amount)
    {
        essences += amount;
        essenceDisplay.text = essences.ToString();

    }
    
}
