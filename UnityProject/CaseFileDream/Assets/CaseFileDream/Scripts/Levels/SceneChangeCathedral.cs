using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeCathedral : MonoBehaviour
{
    public bool hasEntered = false;
    //DoorUp doorUp;
    //public GameObject defaultPreview;
    //public GameObject forestPreview;
    //public Animator anim;

    public void change()
    {
       
    }

    public void Awake()
    {
       // doorUp = GameObject.Find("ZyhiemDoorTrigger").GetComponent<DoorUp>();
    }

    public void Start()
    {
        //anim.enabled = true;
        
    }
    public void Update()
    {
        if (hasEntered == true && Input.GetButtonDown("Fire2"))// && doorUp.canEnter == true)
        {
            LevelManager.Instance.LoadScene("Cathedral", "CrossFade");
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            hasEntered = true;
            
            //defaultPreview.GetComponent<Renderer>().enabled = false;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
        //defaultPreview.GetComponent<Renderer>().enabled = true;
        

    }
}
