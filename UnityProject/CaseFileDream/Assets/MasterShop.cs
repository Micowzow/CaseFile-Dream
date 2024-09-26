using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterShop : MonoBehaviour
{
    public GameObject racOne;
    public GameObject racTwo;
    public GameObject racQuestItem;

    public bool boughtEverything = false;

    void Start()
    {
        racOne.SetActive(true);
        racTwo.SetActive(false);
        racQuestItem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
     if(GameObject.Find("Item1").GetComponent<ShopTicket>().hasTicket == true &&
            GameObject.Find("Item2").GetComponent<ShopBubble>().hasBubble == true &&
            GameObject.Find("Item3").GetComponent<ShopScissors>().hasScissors == true &&
            GameObject.Find("Item4").GetComponent<ShopNut>().hasNut == true)
        {
            boughtEverything = true;
            Debug.Log("All Items bought");
            racOne.SetActive(false);
            racTwo.SetActive(true);
            racQuestItem.SetActive(true);

        }   
    }
}
