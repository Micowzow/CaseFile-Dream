using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TreeNutQuest : MonoBehaviour
{
    public Collider2D depositArea;
    public int numberOfQuestItems;
    public GameObject birdQuestItem;

    public GameObject birdOne;
    public GameObject birdTwo;
    

    public bool inArea;

    public NutManager nutManager;

    public TextMeshProUGUI nutDisplay;
    public Image nutImage;

    // Start is called before the first frame update
    void Start()
    {
        numberOfQuestItems = 0;
        birdOne.SetActive(true);
        birdTwo.SetActive(false);
        nutManager = NutManager.instance;
        inArea = false;
        nutDisplay.enabled = false;
        nutImage.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nutManager.nuts == 4 && inArea == true)
        {
            Debug.Log("all Nuts present");
            birdOne.SetActive(false);
            birdTwo.SetActive(true);
            Instantiate(birdQuestItem);
            nutManager.nuts = 0;
            Destroy(gameObject);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "TreeNut")
        {
            numberOfQuestItems += 1;

        }

        if (collider.gameObject.tag == "Player")
        {
            inArea = true;
            nutDisplay.enabled = true;
            nutImage.enabled = true;

        }


    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "TreeNut")
        {
            numberOfQuestItems -= 1;

        }

        if (collider.gameObject.tag == "Player")
        {
            inArea = false;

        }
    }

}
