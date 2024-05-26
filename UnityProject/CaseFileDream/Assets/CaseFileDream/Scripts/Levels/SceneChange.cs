using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool hasEntered = false;
    DoorUp doorUp;
    public void change()
    {
       
    }

    public void Awake()
    {
        doorUp = GameObject.Find("OldGoatMan (1)").GetComponent<DoorUp>();
    }
    public void Update()
    {
        if (hasEntered == true && Input.GetKeyDown(KeyCode.F) && doorUp.canEnter == true)
        {
            LevelManager.Instance.LoadScene("New Scene", "CrossFade");
        }
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            hasEntered = true;

        }

    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;

    }
}
