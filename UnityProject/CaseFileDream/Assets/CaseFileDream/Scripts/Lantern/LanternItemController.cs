using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Unity.UI;

public class LanternItemController : MonoBehaviour
{
    public Transform lantern;

    public bool isLanternBlue = false;
    public bool isLanternPink = false;
    public bool isLanternRed = false;


    public ParticleSystem psBlue;
    public ParticleSystem psPink;
    public ParticleSystem psRed;

    public Light2D blueLight;
    public Light2D pinkLight;
    public Light2D redLight;

    public GameObject blueFlame;
    public GameObject pinkFlame;
    public GameObject redFlame;

    public bool inRangeBlue = false;
    public bool inRangePink = false;
    public bool inRangeRed = false;
    public bool facingRight = true;


    // Start is called before the first frame update
    void Awake()
    {
        //psBlue.Stop();
        //psPink.Stop();
        blueLight.enabled = false;
        pinkLight.enabled = false;
        redLight.enabled = false;

        blueFlame.SetActive (false);
        redFlame.SetActive(false);
        pinkFlame.SetActive(false);

        Physics2D.IgnoreLayerCollision(9,7);
        Physics2D.IgnoreLayerCollision(10,7);
        
    }

    // Update is called once per frame
    void Update()
    {
      
        float move = Input.GetAxisRaw("Horizontal");

        if (move < 0 && facingRight)
            {
                Flip();
                
            }
            else if(move>0 && !facingRight)
            {
                Flip();
                
            }

        if (inRangeBlue == true && Input.GetButtonDown("Fire2"))
        {
            LightBlueLantern();
        }
        if (inRangePink == true && Input.GetButtonDown("Fire2"))
        {
            LightPinkLantern();
        }
        if (inRangeRed == true && Input.GetButtonDown("Fire2"))
        {
            LightRedLantern();
        }
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("BlueRefill"))
        {
            inRangeBlue = true;
            
        }

        if (collision.gameObject.CompareTag("PinkRefill"))
        {
            inRangePink = true;
            
        }
        if (collision.gameObject.CompareTag("RedRefill"))
        {
            inRangeRed = true;
            
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        inRangeBlue = false;
        inRangePink = false;
        inRangeRed = false;
    }
    #region Blue Lantern Fire
    public void LightBlueLantern()
    {      
            Debug.Log("LightLanternBlue");
            isLanternBlue = true;
            psBlue.Play();
            blueLight.enabled = true;
            blueFlame.SetActive(true);
    }

    public void DouseBlueLantern()
    {
        isLanternBlue = false;
        blueLight.enabled = false;
        psBlue.Stop();
        blueFlame.SetActive(false);
    }
    #endregion


    #region Pink Lantern Fire
    public void LightPinkLantern()
    {       
            Debug.Log("LightLanternPink");
            isLanternPink = true;
            psPink.Play();
            pinkLight.enabled = true;
            pinkFlame.SetActive(true);
    }
    public void DousePinkLantern()
    {
        isLanternPink = false;
        psPink.Stop();
        pinkLight.enabled = false;
        pinkFlame.SetActive(false);

    }
    #endregion


    #region Red Lantern Fire
    public void LightRedLantern()
    {        
            Debug.Log("LightLanternRed");
            isLanternRed = true;
            psRed.Play();
            redLight.enabled = true;
            redFlame.SetActive(true);

    }

    public void DouseRedLantern()
    {
        isLanternRed = false;
        redLight.enabled = false;
        psRed.Stop();
        redFlame.SetActive(false);
    }
    #endregion



    public void Flip()
        {
            facingRight = !facingRight; //if player is not facing right flip transform
            transform.Rotate(0f, 180f, 0f);
        }
}
