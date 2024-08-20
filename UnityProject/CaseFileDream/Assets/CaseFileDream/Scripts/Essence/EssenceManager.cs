using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EssenceManager : MonoBehaviour, IDataPersistance
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

   public void LoadData(GameData data)
    {
        this.essences = data.essenceCount;
    }

    public void SaveData(ref GameData data)
    {
        data.essenceCount = this.essences;
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
