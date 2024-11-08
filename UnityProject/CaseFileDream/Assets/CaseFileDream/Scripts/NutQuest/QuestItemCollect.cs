using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class QuestItemCollect : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private QuestItemManager questManager;

    [SerializeField] private PlayableDirector playableDirectorItemsCollected;

    private void Start()
    {
        questManager = QuestItemManager.instance;

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Added 1 Nut");
            questManager.ChangeItem(value);
            playableDirectorItemsCollected.Play();
            Destroy(gameObject);

        }
    }
}
