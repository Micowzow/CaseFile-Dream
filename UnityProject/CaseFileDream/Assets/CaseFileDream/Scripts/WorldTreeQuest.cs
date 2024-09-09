using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTreeQuest : MonoBehaviour
{
    public Collider2D depositArea;
    public int numberOfQuestItems;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfQuestItems == 4)
        {
            Debug.Log("all items present");

        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        
        if (collider.gameObject.tag == "Questitem")
        {
            numberOfQuestItems += 1;
                       
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider) 
    {
        if (collider.gameObject.tag == "Questitem")
        {
            numberOfQuestItems -= 1;
                       
        }
    }
    
}
