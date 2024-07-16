using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorUp : MonoBehaviour
{
    public Animator anim;
    bool canOpen;
    public bool isOpen = false;
    public bool canEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        anim.enabled = true;
        anim.SetBool("isOpen", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpen == true && Input.GetButtonDown("Fire2"))
        {

            AnimStart();

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            canOpen = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canOpen = false;

    }

    void AnimStart()
    {
        anim.SetBool("isOpen", true);
        isOpen = true;
        canEnter = true;
    }
}
