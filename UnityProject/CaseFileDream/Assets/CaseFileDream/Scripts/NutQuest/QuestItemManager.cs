using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestItemManager : MonoBehaviour
{
    public static QuestItemManager instance;

    public int questItem;
    public TextMeshProUGUI numDisplay;

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
        numDisplay.text = questItem.ToString();

    }

    public void ChangeItem(int amount)
    {
        questItem += amount;
        numDisplay.text = questItem.ToString();

    }
    
}
