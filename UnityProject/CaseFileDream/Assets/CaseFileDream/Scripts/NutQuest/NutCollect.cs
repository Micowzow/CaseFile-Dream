using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutCollect : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private NutManager nutManager;

    private void Start()
    {
        nutManager = NutManager.instance;

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Debug.Log("Added 1 Nut");
            nutManager.ChangeNuts(value);
            Destroy(gameObject);

        }
    }
}
