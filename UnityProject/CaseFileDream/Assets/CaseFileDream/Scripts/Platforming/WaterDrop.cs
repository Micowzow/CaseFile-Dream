using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WaterDrop : MonoBehaviour
{
    public Transform doorswitch;
    public Transform downPos;
    public Transform upperPos;
    public Transform lantern;

    public float speed;
    bool isDoorDown;


    // Update is called once per frame
    private void Start()
    {
        
    }
    void Update()
    {
        LowerWater();
        

    }

    public void LowerWater()
    {
        //If next to door switch and Q key is pressed and isLanternLit is true
        if (Vector2.Distance(lantern.position, doorswitch.position) < 2.5f && Input.GetButtonDown("Fire2") && gameObject.tag == "Ticket")
        {
            
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
