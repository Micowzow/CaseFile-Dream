using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PolarbearQuest : MonoBehaviour
{
    public Transform doorswitch;
    public Transform downPos;
    public Transform upperPos;
    public Transform lantern;

    public float speed;
    bool isDoorDown;
    public bool doorActivated;

     public GameObject bearOne;
    public GameObject bearTwo;

    public Light2D light;
    public ParticleSystem pS;

    // Update is called once per frame
    private void Start()
    {
        light.enabled = false;
        pS.Stop();

        bearOne.SetActive(true);
        bearTwo.SetActive(false);
    }
    void Update()
    {
        StartBlueDoor();

        if(doorActivated == true)
        {
            bearOne.SetActive(false);
            bearTwo.SetActive(true);

        }
        
    }

    public void StartBlueDoor()
    {
        //If next to door switch and Q key is pressed and isLanternLit is true
        if (Vector2.Distance(lantern.position, doorswitch.position) < 2.5f && Input.GetButtonDown("Fire2") && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternBlue == true && gameObject.tag == "BlueInteract")
        {
            lantern.GetComponent<LanternItemController>().DouseBlueLantern();
            Debug.Log("LiftBlueDoor");
            light.enabled = true;
            doorActivated = true;
            pS.Play();
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
