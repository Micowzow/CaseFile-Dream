using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternItemController : MonoBehaviour
{
    public Transform lantern;

    public bool isLitlantern = false;

    public Transform refillStation;


    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        LightLantern();
    }

    public void LightLantern()
    {
        if (Vector2.Distance(lantern.position, refillStation.position) < 2.5f && Input.GetKeyDown("q"))
        {
            Debug.Log("LightLantern");
            isLitlantern = true;


        }
        else
        {
            return;
        }
            

    }

    public void DouseLantern()
    {
        isLitlantern = false;
    }

   
}
