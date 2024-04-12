using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform player;
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;
    public Transform lantern;
    public Transform recallElevator;


    public float speed;
    bool isElevaterDown;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        StartElevator();


    }

    public void StartElevator()
    {
        //If next to elevator switch and Q key is pressed and isLanternLit is true
        if(Vector2.Distance(lantern.position,elevatorSwitch.position)<2.5f && Input.GetKeyDown("q") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLitlantern == true)
        {
            lantern.GetComponent<LanternItemController>().DouseLantern();
            Debug.Log("StartedElevator/door");
            if(transform.position.y <= downPos.position.y)
            {
                isElevaterDown = true;
            }
            else if(transform.position.y >= upperPos.position.y)
            {
                isElevaterDown = false;
            }
        }

        if (isElevaterDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }



        //If next to elevator switch and Q key is pressed and isLanternLit is true
        if (Vector2.Distance(lantern.position, recallElevator.position) < 2.5f && Input.GetKeyDown("q") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLitlantern == true)
        {
            lantern.GetComponent<LanternItemController>().DouseLantern();
            Debug.Log("StartedElevator/door");
            if (transform.position.y <= downPos.position.y)
            {
                isElevaterDown = true;
            }
            else if (transform.position.y >= upperPos.position.y)
            {
                isElevaterDown = false;
            }
        }

        if (isElevaterDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }

    }

    
    }

    



