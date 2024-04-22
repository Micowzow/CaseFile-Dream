using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    Respawning respawning;
    // Start is called before the first frame update
    void Awake()
    {
        respawning = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawning>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            respawning.UpdateCheckpoint(transform.position);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
