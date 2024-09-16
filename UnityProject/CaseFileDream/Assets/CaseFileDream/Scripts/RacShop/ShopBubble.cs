using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopBubble : MonoBehaviour
{
    public GameObject bubble;
    public EssenceManager essenceManager;

    public Transform spawnPosition;

    public bool hasBubble = false;

    public TextMeshProUGUI essenceDisplay;

    public int bubbleAmount;


    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && essenceManager.essences >= bubbleAmount && hasBubble == false&& Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Spaw Bubble");
            Instantiate(bubble,spawnPosition.position, spawnPosition.rotation);
            hasBubble = true;
            essenceManager.essences -= bubbleAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }
    }
}
