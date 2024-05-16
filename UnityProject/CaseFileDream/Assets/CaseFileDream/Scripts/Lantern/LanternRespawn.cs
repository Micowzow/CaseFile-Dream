using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternRespawn : MonoBehaviour
{
    public Transform lantern;
    public Transform player;
    public float respawnDistance;

    public Vector2 checkpointPos;

    
    void Start()
    {
        checkpointPos = transform.position;

    }


    void Update()
    {
        if (Vector2.Distance(lantern.position, player.position) > respawnDistance)
        {
            RespawnLantern();
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Water"))
        {
            lantern.transform.parent = null;
            RespawnLantern();
                      
        }


       
    }

    public void RespawnLantern()
    {
       
        transform.position = checkpointPos;
        transform.localScale = new Vector3(2.543644f, 2.543644f, 2.543644f);
    }
     

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

   
}
