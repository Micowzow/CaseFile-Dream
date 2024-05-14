using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LanternItemController : MonoBehaviour
{
    public Transform lantern;

    public bool isLanternBlue = false;
    public bool isLanternPink = false;
    public bool isLanternRed = false;

    public Transform refillStationBlue;
    public Transform refillStationBlueTwo;
    public Transform refillStationPink;
    public Transform refillStationBlueThree;
    public Transform refillStationRed;

    public ParticleSystem psBlue;
    public ParticleSystem psPink;
    public ParticleSystem psRed;

    public Light2D blueLight;
    public Light2D pinkLight;
    public Light2D redLight;

    public bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        //psBlue.Stop();
        //psPink.Stop();
        blueLight.enabled = false;
        pinkLight.enabled = false;
        redLight.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        LightBlueLantern();
        LightBlueLanternTwo();
        LightPinkLantern();
        LightBlueLanternThree();
        LightRedLantern();

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
        if (Vector2.Distance(lantern.position, refillStationBlue.position) < 2.5f && Input.GetKeyDown("f"))
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

    #region Blue Lantern Fire Two
    public void LightBlueLanternTwo()
    {
        if (Vector2.Distance(lantern.position, refillStationBlueTwo.position) < 2.5f && Input.GetKeyDown("f"))
        {
            Debug.Log("LightLanternBlue");
            isLanternBlue = true;
            psBlue.Play();
            blueLight.enabled = true;

        }

    }

    public void DouseBlueLanternTwo()
    {
        isLanternBlue = false;
        blueLight.enabled = false;
        psBlue.Stop();
    }
    #endregion

    #region Blue Lantern Fire Three
    public void LightBlueLanternThree()
    {
        if (Vector2.Distance(lantern.position, refillStationBlueThree.position) < 2.5f && Input.GetKeyDown("f"))
        {
            Debug.Log("LightLanternPink");
            isLanternBlue = true;
            psBlue.Play();
            blueLight.enabled = true;

        }

    }

    public void DouseBlueLanternThree()
    {
        isLanternBlue = false;
        psBlue.Stop();
        blueLight.enabled = false;
    }
    #endregion

    #region Pink Lantern Fire
    public void LightPinkLantern()
    {
        if (Vector2.Distance(lantern.position, refillStationPink.position) < 2.5f && Input.GetKeyDown("f"))
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


    #region Red Lantern Fire
    public void LightRedLantern()
    {
        if (Vector2.Distance(lantern.position, refillStationRed.position) < 2.5f && Input.GetKeyDown("f"))
        {
            Debug.Log("LightLanternRed");
            isLanternRed = true;
            psRed.Play();
            redLight.enabled = true;

        }

    }

    public void DouseRedLantern()
    {
        isLanternRed = false;
        redLight.enabled = false;
        psRed.Stop();
    }
    #endregion



    public void Flip()
        {
            facingRight = !facingRight; //if player is not facing right flip transform
            transform.Rotate(0f, 180f, 0f);
        }
}
