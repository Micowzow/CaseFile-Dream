using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestItemCollect : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private QuestItemManager questManager;

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
            Destroy(gameObject);

        }
    }
}
