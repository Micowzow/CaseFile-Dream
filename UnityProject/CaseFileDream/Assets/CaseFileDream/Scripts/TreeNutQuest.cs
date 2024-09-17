using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNutQuest : MonoBehaviour
{
    public Collider2D depositArea;
    public int numberOfQuestItems;
    public GameObject birdQuestItem;

    // Start is called before the first frame update
    void Start()
    {
        numberOfQuestItems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfQuestItems == 8)
        {
            Debug.Log("all Nuts present");
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
