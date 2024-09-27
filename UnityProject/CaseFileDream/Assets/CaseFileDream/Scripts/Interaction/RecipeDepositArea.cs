using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeDepositArea : MonoBehaviour
{
    public GameObject skunkQuestItem;

    public GameObject skunkOne;
    public GameObject skunkTwo;
    // Start is called before the first frame update
    void Start()
    {
        skunkOne.SetActive(true);
        skunkTwo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {

        if (collider.gameObject.tag == "Recipe")
        {
            skunkOne.SetActive(false);
            skunkTwo.SetActive(true);
            Instantiate(skunkQuestItem);
            Destroy(gameObject);

        }


    }
}
