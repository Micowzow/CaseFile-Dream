using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool hasEntered = false;
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasEntered = true;

        if(collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        hasEntered = true;

        if (collision.tag == "Player" && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        FindObjectOfType<DialogueManager>().EndDialogue();

    }
}
