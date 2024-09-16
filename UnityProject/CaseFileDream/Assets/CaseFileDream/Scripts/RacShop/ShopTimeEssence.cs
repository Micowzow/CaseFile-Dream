using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTimeEssence : MonoBehaviour
{
    

    public GameObject bud;

    public Transform spawnPosition;

    
    public EssenceManager essenceManager;

    

    public bool hasBud = false;

    public TextMeshProUGUI essenceDisplay;

    
    public int budAmount;
   
    
    
    private void OnTriggerStay2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Player" && essenceManager.essences >= budAmount && hasBud == false && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Spawn scissors");
            Instantiate(bud, spawnPosition.position, spawnPosition.rotation);
            hasBud = true;
            essenceManager.essences -= budAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }

    }
}

