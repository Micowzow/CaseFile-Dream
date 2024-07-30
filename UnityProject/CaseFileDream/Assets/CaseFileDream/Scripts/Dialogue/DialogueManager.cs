using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public DialogueTrigger dialogueTrigger;
    public Animator animator;

    public TMP_Text nameText;
    public TMP_Text dialogueText;
    private Queue<string> sentences;

    public bool isDialogueActive = false;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (Instance == null)
            Instance = this;
        sentences = new Queue<string>();
    }

    public void Update()
    {
        
    }
    public void StartDialogue (Dialogue dialogue)
    {
        
        animator.SetBool("isOpen", true);
        isDialogueActive = true;
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);

        }

            DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

       string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
                yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        isDialogueActive = false;
    }

}
