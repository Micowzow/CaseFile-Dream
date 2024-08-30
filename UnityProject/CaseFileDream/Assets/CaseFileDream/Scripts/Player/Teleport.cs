using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform destination;
    public Animator animator;
    GameObject player;
    public GameObject teleportBlack;
    

    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        teleportBlack.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Player"))
        {
            if(Vector2.Distance(player.transform.position, transform.position) > 1f)
            {
                StartCoroutine(TeleportIn());
                
            }
            
        }
        
    }
    
    IEnumerator TeleportIn()
    {
        teleportBlack.SetActive(true);
        animator.SetBool("isTeleporting", true);
        yield return new WaitForSeconds(1f);
        player.transform.position = destination.transform.position;
        animator.SetBool("isTeleporting", false);
        

    }
}
