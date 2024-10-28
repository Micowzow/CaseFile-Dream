using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class SpawnHeartInChurch : MonoBehaviour
{
    public Animator animator;
    public bool heartPlaced;
    public ParticleSystem ps;
    
    [SerializeField] private PlayableDirector playableDirector;

    void Start()
    {
        animator.SetBool("hasPlaced", false);
       heartPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateHeart()
    {
        if(gameObject.CompareTag("Player") && Input.GetButtonDown("Fire2"))
        {
            ps.Play();
            heartPlaced = true;

        }

    }

     private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            animator.SetBool("hasPlaced", true);
            playableDirector.Play();
            GetComponent<BoxCollider2D>().enabled = false;
        }

        if(gameObject.CompareTag("Player") && Input.GetKeyDown("Fire2") && heartPlaced == true)
        {
            ps.Play();
            

        }
    }
}
