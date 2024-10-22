using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopScissors : MonoBehaviour
{
    

    public GameObject scissors;

    public Transform spawnPosition;

    
    public EssenceManager essenceManager;

    

    public bool hasScissors = false;

    public TextMeshProUGUI essenceDisplay;

    
    public int scissorsAmount;
    public SpriteRenderer displayImage;


    private void OnTriggerStay2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Player" && essenceManager.essences >= scissorsAmount && hasScissors == false && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Spawn scissors");
            Instantiate(scissors, spawnPosition.position, spawnPosition.rotation);
            hasScissors = true;
            essenceManager.essences -= scissorsAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
            displayImage.enabled = false;
        }

    }
}
