using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool canTalk = false;

    public bool isTalking = false;

    public void Update()
    {
        if(canTalk == true && Input.GetButtonDown("Fire2") && isTalking == false)
        {
            Debug.Log("Talking");
            TriggerDialogue();

        }

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        isTalking = true;

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            canTalk = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();
        canTalk = false;
        isTalking = false;

    }
}
