using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
public class ElevatorBlue : MonoBehaviour
{
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;
    public Transform lantern;
    public Transform recallElevator;
    public Transform recallElevatorTwo;


    public ParticleSystem pS;
    public Light2D blueLight;


    public float speed;
    bool isElevaterDown;
    public bool hasBeenActivated;

    private void Start()
    {
        blueLight.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        StartElevatorBlue();

    }

    public void StartElevatorBlue()
    {
        //If next to elevator switch and F key is pressed and isLanternLit is true
        if(Vector2.Distance(lantern.position,elevatorSwitch.position)<2f && Input.GetButtonDown("Fire2") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternBlue == true)
        {
            lantern.GetComponent<LanternItemController>().DouseBlueLantern();
            Debug.Log("StartedElevator/door");
            pS.Play();
            blueLight.enabled = true;
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

        //If Elevator is gone recall at recall station
        if (Vector2.Distance(lantern.position, recallElevatorTwo.position) < 2.5f && Input.GetButtonDown("Fire2") && hasBeenActivated == true)
        {
            Debug.Log("StartedElevator");
            recallElevatorTwo.transform.Rotate(0f, 180f, 0f);
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

    

    

    



