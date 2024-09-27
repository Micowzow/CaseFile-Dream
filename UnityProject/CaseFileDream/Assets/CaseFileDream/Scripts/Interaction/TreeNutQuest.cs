using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNutQuest : MonoBehaviour
{
    public Collider2D depositArea;
    public int numberOfQuestItems;
    public GameObject birdQuestItem;

    public GameObject birdOne;
    public GameObject birdTwo;

    // Start is called before the first frame update
    void Start()
    {
        numberOfQuestItems = 0;
        birdOne.SetActive(true);
        birdTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfQuestItems == 8)
        {
            Debug.Log("all Nuts present");
            birdOne.SetActive(false);
            birdTwo.SetActive(true);
            Instantiate(birdQuestItem);
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "TreeNut")
        {
            numberOfQuestItems += 1;

        }


    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "TreeNut")
        {
            numberOfQuestItems -= 1;

        }
    }

}
