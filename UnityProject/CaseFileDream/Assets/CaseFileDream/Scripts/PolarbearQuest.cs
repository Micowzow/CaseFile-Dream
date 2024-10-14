using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PolarbearQuest : MonoBehaviour
{
    public Transform doorswitch;
    
    public Transform lantern;

    public Animator anim;
    public float speed;
    bool isDoorDown;
    public bool doorActivated;

    public GameObject bearQuestItem;

     public GameObject bearOne;
    public GameObject bearTwo;

    

    // Update is called once per frame
    private void Start()
    {
        
        anim.SetBool("hasMelted", false);
        bearOne.SetActive(true);
        bearTwo.SetActive(false);
    }
    void Update()
    {
        MeltIce();

        if(doorActivated == true)
        {
            
            bearOne.SetActive(false);
            bearTwo.SetActive(true);
            StartCoroutine(Melt());

        }
        
    }

    public void MeltIce()
    {
        //If next to door switch and Q key is pressed and isLanternLit is true
        if (Vector2.Distance(lantern.position, doorswitch.position) < 2.5f && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternPink == true
                                                                                                            && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternBlue == true
                                                                                                            && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternRed == true
                                                                                                            && GameObject.Find("GrabItem").GetComponent<LanternItemController>().isLanternYellow == true)
        {
            //lantern.GetComponent<LanternItemController>().DousePinkLantern();
            //lantern.GetComponent<LanternItemController>().DouseBlueLantern();
            //lantern.GetComponent<LanternItemController>().DouseRedLantern();
            //lantern.GetComponent<LanternItemController>().DouseYellowLantern();
            Debug.Log("LiftPinkDoor");
            doorActivated = true;
            
            
        }

        


    }

    IEnumerator Melt()
    {
        anim.SetBool("hasMelted", true);
        yield return new WaitForSeconds(2f);
        Instantiate(bearQuestItem);

        Destroy(gameObject);
    }

    
}
