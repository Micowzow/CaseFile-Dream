using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorswitch;
    public Transform downPos;
    public Transform upperPos;
    public Transform lantern;
    

    public float speed;
    bool isDoorDown;
   
    // Update is called once per frame
    void Update()
    {
        StartBlueDoor();
        StartPinkDoor();

    }

    public void StartBlueDoor()
    {
        //If next to door switch and Q key is pressed and isLanternLit is true
        if (Vector2.Distance(lantern.position, doorswitch.position) < 2.5f && Input.GetKeyDown("q") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternBlue == true && gameObject.tag == "BlueInteract")
        {
            lantern.GetComponent<LanternItemController>().DouseBlueLantern();
            Debug.Log("LiftBlueDoor");
            if (transform.position.y <= downPos.position.y)
            {
                isDoorDown = true;
            }
            else if (transform.position.y >= upperPos.position.y)
            {
                isDoorDown = false;
            }
        }

        if (isDoorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }


    }

    public void StartPinkDoor()
    {
        //If next to door switch and Q key is pressed and isLanternLit is true
        if (Vector2.Distance(lantern.position, doorswitch.position) < 2.5f && Input.GetKeyDown("q") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternPink == true && gameObject.tag == "PinkInteract")
        {
            lantern.GetComponent<LanternItemController>().DousePinkLantern();
            Debug.Log("LiftPinkDoor");
            if (transform.position.y <= downPos.position.y)
            {
                isDoorDown = true;
            }
            else if (transform.position.y >= upperPos.position.y)
            {
                isDoorDown = false;
            }
        }

        if (isDoorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }


    }
}
