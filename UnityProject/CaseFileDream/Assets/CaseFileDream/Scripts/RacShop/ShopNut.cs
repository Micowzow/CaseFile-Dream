using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopNut : MonoBehaviour
{
    

    public GameObject nut;

    public Transform spawnPosition;

    
    public EssenceManager essenceManager;

    

    public bool hasNut = false;

    public TextMeshProUGUI essenceDisplay;

    
    public int nutAmount;

    public SpriteRenderer displayImage;

    private void OnTriggerStay2D(Collider2D collider)
    {
       
        if (collider.gameObject.tag == "Player" && essenceManager.essences >= nutAmount && hasNut == false && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Spawn scissors");
            Instantiate(nut, spawnPosition.position, spawnPosition.rotation);
            hasNut = true;
            essenceManager.essences -= nutAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
            displayImage.enabled = false;
        }

    }
}
