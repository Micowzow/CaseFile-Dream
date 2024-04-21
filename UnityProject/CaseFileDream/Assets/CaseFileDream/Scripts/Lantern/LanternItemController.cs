using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternItemController : MonoBehaviour
{
    public Transform lantern;

    public bool isLanternBlue = false;
    public bool isLanternPink = false;

    public Transform refillStationBlue;
    public Transform refillStationPink;
    public Transform refillStationPinkTwo;

    public ParticleSystem psBlue;
    public ParticleSystem psPink;

    public Light2D blueLight;
    public Light2D pinkLight;

    public bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        //psBlue.Stop();
        //psPink.Stop();
        blueLight.enabled = false;
        pinkLight.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        LightBlueLantern();
        LightPinkLantern();
        LightPinkLanternTwo();

        float move = Input.GetAxisRaw("Horizontal");

        if (move < 0 && facingRight)
            {
                Flip();
                
            }
            else if(move>0 && !facingRight)
            {
                Flip();
                
            }
    }
    #region Blue Lantern Fire
    public void LightBlueLantern()
    {
        if (Vector2.Distance(lantern.position, refillStationBlue.position) < 2.5f && Input.GetKeyDown("q"))
        {
            Debug.Log("LightLanternBlue");
            isLanternBlue = true;
            psBlue.Play();
            blueLight.enabled = true;

        }               

    }

    public void DouseBlueLantern()
    {
        isLanternBlue = false;
        blueLight.enabled = false;
        psBlue.Stop();
    }
    #endregion

    #region Pink Lantern Fire
    public void LightPinkLantern()
    {
        if (Vector2.Distance(lantern.position, refillStationPink.position) < 2.5f && Input.GetKeyDown("q"))
        {
            Debug.Log("LightLanternPink");
            isLanternPink = true;
            psPink.Play();
            pinkLight.enabled = true;

        }
        
    }

    public void DousePinkLantern()
    {
        isLanternPink = false;
        psPink.Stop();
        pinkLight.enabled = false;
    }
    #endregion

    #region Pink Lantern Fire Two
    public void LightPinkLanternTwo()
    {
        if (Vector2.Distance(lantern.position, refillStationPinkTwo.position) < 2.5f && Input.GetKeyDown("q"))
        {
            Debug.Log("LightLanternPink");
            isLanternPink = true;
            psPink.Play();
            pinkLight.enabled = true;

        }

    }

    public void DousePinkLanternTwo()
    {
        isLanternPink = false;
        psPink.Stop();
        pinkLight.enabled = false;
    }
    #endregion



    public void Flip()
        {
            facingRight = !facingRight; //if player is not facing right flip transform
            transform.Rotate(0f, 180f, 0f);
        }
}
