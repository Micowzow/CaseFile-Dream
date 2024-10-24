using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanternInteraction : MonoBehaviour
{
    public int fullCharge = 4; 
    public int currentCharge;

    public bool isInCollission = false;
    // Start is called before the first frame update
    void Start()
    {
        currentCharge = fullCharge;
    }


    void UseCharge(int amount)
    {
        currentCharge -= amount;

        if(currentCharge <= 0)
        {
            //No charge can be used
        }
    }

    void RefillCharge(int amount)
    {
        currentCharge += amount;

        if(currentCharge >= fullCharge)
        {
            //No added charge
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInCollission == false)
        {
            isInCollission = true;
            if (collision.tag == "LanternInteract" && Input.GetKeyDown("q"))
            {
                UseCharge(1);
            }

            if (collision.tag == "LanternRefill" && Input.GetKeyDown("q"))
            {
                RefillCharge(1);
            }
        }
        else
        {
            isInCollission = false;
        }
    }

   
}
