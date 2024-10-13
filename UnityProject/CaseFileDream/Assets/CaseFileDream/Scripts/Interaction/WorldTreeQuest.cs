using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class WorldTreeQuest : MonoBehaviour
{
    public Collider2D depositArea;
    public int numberOfQuestItems;

    public GameObject blockage;

    public GameObject worldHeart;

    public GameObject treeOne;
    public GameObject treeTwo;

    public Transform spawnPosition;


    //[SerializeField] private PlayableDirector playableDirector;

    // Start is called before the first frame update
    void Start()
    {
        treeOne.SetActive(true);
        treeTwo.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(numberOfQuestItems == 4)
        {
            Debug.Log("all items present");
            //playableDirector.Play();
            Destroy(blockage);
            Instantiate(worldHeart, spawnPosition.position, spawnPosition.rotation);
            Destroy(gameObject);
            treeOne.SetActive(false);
            treeTwo.SetActive(true);

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
