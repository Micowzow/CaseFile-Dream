using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopTicket : MonoBehaviour
{
    

    public GameObject ticket;

    public Transform spawnPosition;

    
    public EssenceManager essenceManager;

    

    public bool hasTicket = false;

    public TextMeshProUGUI essenceDisplay;

    
    public int ticketAmount;
   
    
    
    private void OnTriggerStay2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Player" && essenceManager.essences >= ticketAmount && hasTicket == false && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Spawn ticket");
            Instantiate(ticket, spawnPosition.position, spawnPosition.rotation);
            hasTicket = true;
            essenceManager.essences -= ticketAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }

    }
}
