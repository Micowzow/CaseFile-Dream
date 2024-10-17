using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class QuestItem : MonoBehaviour
{
    public Collider2D depositArea;
    public int numberOfQuestItems;


    public GameObject blockage;

    public GameObject worldHeart;

    public GameObject treeOne;
    public GameObject treeTwo;

    public Transform spawnPosition;


    public bool inArea;

    public QuestItemManager questManager;

    public TextMeshProUGUI nutDisplay;
    public Image nutImage;

    

    // Start is called before the first frame update
    void Start()
    {
        numberOfQuestItems = 0;
        
        questManager = QuestItemManager.instance;
        inArea = false;
        nutDisplay.enabled = true;
        nutImage.enabled = true;

        treeOne.SetActive(true);
        treeTwo.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (questManager.questItem == 4 && inArea == true)
        {
            Debug.Log("all Items present");

            Destroy(blockage);
            Instantiate(worldHeart, spawnPosition.position, spawnPosition.rotation);
            Destroy(gameObject);
            treeOne.SetActive(false);
            treeTwo.SetActive(true);

            questManager.questItem = 0;
            nutDisplay.text = 0.ToString();
            
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Questitem")
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
