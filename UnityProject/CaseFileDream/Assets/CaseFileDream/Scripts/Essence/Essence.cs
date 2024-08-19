using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private EssenceManager essenceManager;

    private void Start()
    {
        essenceManager = EssenceManager.instance;

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Added 1 value");
            essenceManager.ChangeEssences(value);
            Destroy(gameObject);

        }
    }
}
