using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public bool hasEntered = false;
    public void change()
    {
       
    }
    public void Update()
    {
        
    }


    public void OnTriggerStay2D(Collider2D collision)
    {
        hasEntered = true;

        if (collision.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.F))
        {
            LevelManager.Instance.LoadScene("New Scene", "CrossFade");
        }

    }
}
