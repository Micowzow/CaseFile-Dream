using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAudioRac : MonoBehaviour
{
    private bool playerInRange;
    private bool isTalking;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        isTalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && isTalking == false && Input.GetButtonDown("Fire2"))
        {
            FindObjectOfType<AudioManager>().Play("RacDialogue");
            isTalking = true;
        }
        else
        {
            
        }
        
    
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            playerInRange = false;
            FindObjectOfType<AudioManager>().Stop("ElkDialogue");
            isTalking = false;

        }
        
    }
}
