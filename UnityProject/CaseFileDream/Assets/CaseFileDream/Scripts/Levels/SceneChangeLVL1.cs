using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeLVL1 : MonoBehaviour
{
    public bool hasEntered = false;
    //DoorUp doorUp;
    public GameObject defaultPreview;
    public GameObject forestPreview;
    public Animator anim;
    public Animator animRoots;

    public void change()
    {
       
    }

    public void Awake()
    {
       // doorUp = GameObject.Find("ZyhiemDoorTrigger").GetComponent<DoorUp>();
    }

    public void Start()
    {
        anim.enabled = true;
        anim.SetBool("onPortal", false);
        animRoots.SetBool("hasEntered", false);
    }
    public void Update()
    {
        if (hasEntered == true && Input.GetButtonDown("Fire2"))// && doorUp.canEnter == true)
        {
            LevelManager.Instance.LoadScene("Level01", "CrossFade");
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            hasEntered = true;
            anim.SetBool("onPortal", true);
            animRoots.SetBool("hasEntered", true);
            //defaultPreview.GetComponent<Renderer>().enabled = false;
        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
        defaultPreview.GetComponent<Renderer>().enabled = true;
        anim.SetBool("onPortal", false);
        animRoots.SetBool("hasEntered", false);

    }
}
