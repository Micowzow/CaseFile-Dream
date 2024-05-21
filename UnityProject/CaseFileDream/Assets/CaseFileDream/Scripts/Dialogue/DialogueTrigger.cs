using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public bool canTalk = false;

    public void Update()
    {
        if(canTalk == true && Input.GetKeyDown(KeyCode.F))
        {
            TriggerDialogue();

        }

    }
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);

    }

    private void OnTriggerEnter2D(Collider2D collision)
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

    }
}
