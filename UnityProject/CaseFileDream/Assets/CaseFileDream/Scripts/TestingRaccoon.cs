using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestingRaccoon : MonoBehaviour
{
    public GameObject bubble;

    public GameObject ticket;

    public GameObject scissors;

    public GameObject nut;
    public EssenceManager essenceManager;

    public bool hasBubble = false;

    public bool hasTicket = false;

    public TextMeshProUGUI essenceDisplay;

    public int bubbleAmount;
    public int ticketAmount;
    public int scissorsAmount;
    public int nutAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && essenceManager.essences >= bubbleAmount && hasBubble == false)
        {
            Debug.Log("Spawn Bubble");
            Instantiate(bubble);
            hasBubble = true;
            essenceManager.essences -= bubbleAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }

        if (collider.gameObject.tag == "Player" && essenceManager.essences >= ticketAmount && hasTicket == false)
        {
            Debug.Log("Spawn ticket");
            Instantiate(ticket);
            hasTicket = true;
            essenceManager.essences -= ticketAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }

        if (collider.gameObject.tag == "Player" && essenceManager.essences >= bubbleAmount && hasBubble == false)
        {
            Debug.Log("Spaw Bubble");
            Instantiate(bubble);
            hasBubble = true;
            essenceManager.essences -= bubbleAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }

        if (collider.gameObject.tag == "Player" && essenceManager.essences >= bubbleAmount && hasBubble == false)
        {
            Debug.Log("Spaw Bubble");
            Instantiate(bubble);
            hasBubble = true;
            essenceManager.essences -= bubbleAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }
    }
}
