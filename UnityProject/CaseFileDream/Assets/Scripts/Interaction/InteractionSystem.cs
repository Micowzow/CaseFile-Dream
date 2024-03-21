using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Fields")]
    //Detection Point
    public Transform detectionPoint;

    //Detection Radius
    private const float detectionRadius=0.2f;

    //Detection Layer
    public LayerMask detectionLayer;

    //Cached Trigger Object
    public GameObject detectedObject;
    [Header("Examine Fields")]
    //Examine Window Object
    public GameObject examineWindow;
    public Image examineImage;
    public TMP_Text examineText;
    public bool isExamining;

    [Header("Others")]
    //List of Picked Up items
    public List<GameObject> pickedItems = new List<GameObject>();

    void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
                Debug.Log("INTERACT");

            }

        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);

    }

    bool DetectObject()
    {
        Collider2D obj = Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);

        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else
        {
            detectedObject = obj.gameObject;
            return true;
        }


    }

    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }

    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            //Hide examine window
            examineWindow.SetActive(false);
            //disable the boolean
            isExamining = false;
        }
        else
        {

        //Show the item image
        examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
        //Write description text
        examineText.text = item.descriptionText;
        //Display an examine window
        examineWindow.SetActive(true);
        //enable the boolean
        isExamining = true;

        }
    }

  
    
}
