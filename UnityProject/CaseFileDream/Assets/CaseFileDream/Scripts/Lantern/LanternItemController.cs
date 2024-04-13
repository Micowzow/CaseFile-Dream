using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternItemController : MonoBehaviour
{
    public Transform lantern;

    public bool isLanternBlue = false;
    public bool isLanternPink = false;

    public Transform refillStationBlue;
    public Transform refillStationPink;

    public ParticleSystem psBlue;
    public ParticleSystem psPink;


    // Start is called before the first frame update
    void Start()
    {
        psBlue.Stop();
        psPink.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        LightBlueLantern();
        LightPinkLantern();
    }
    #region Blue Lantern Fire
    public void LightBlueLantern()
    {
        if (Vector2.Distance(lantern.position, refillStationBlue.position) < 2.5f && Input.GetKeyDown("q"))
        {
            Debug.Log("LightLanternBlue");
            isLanternBlue = true;
            psBlue.Play();


        }
        else
        {
            return;
        }
            

    }

    public void DouseBlueLantern()
    {
        isLanternBlue = false;
        psBlue.Stop();
    }
    #endregion

    public void LightPinkLantern()
    {
        if (Vector2.Distance(lantern.position, refillStationPink.position) < 2.5f && Input.GetKeyDown("q"))
        {
            Debug.Log("LightLanternPink");
            isLanternPink = true;
            psPink.Play();


        }
        else
        {
            return;
        }


    }

    public void DousePinkLantern()
    {
        isLanternPink = false;
        psPink.Stop();
    }
}
