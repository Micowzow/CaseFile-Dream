using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorRed : MonoBehaviour
{
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;
    public Transform lantern;
    public Transform recallElevator;


    public float speed;
    bool isElevaterDown;
    public bool hasBeenActivated;

    // Update is called once per frame
    void Update()
    {
        StartElevatorRed();

    }

    
    public void StartElevatorRed()
    {
        //If next to elevator switch and Q key is pressed and isLanternLit is true
        if(Vector2.Distance(lantern.position,elevatorSwitch.position)<2f && Input.GetButtonDown("Fire2") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternRed == true)
        {
            lantern.GetComponent<LanternItemController>().DouseRedLantern();
            Debug.Log("StartedElevator/door");
            if(transform.position.y <= downPos.position.y)
            {
                isElevaterDown = true;
                hasBeenActivated = true;
            }
            else if(transform.position.y >= upperPos.position.y)
            {
                isElevaterDown = false;
                hasBeenActivated = true;
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

        

        //If Elevator is gone recall at recall station
        if (Vector2.Distance(lantern.position, recallElevator.position) < 2.5f && Input.GetButtonDown("Fire2") && hasBeenActivated == true)
        {
            Debug.Log("StartedElevator");
            recallElevator.transform.Rotate(0f, 180f, 0f);
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

    

    

    



