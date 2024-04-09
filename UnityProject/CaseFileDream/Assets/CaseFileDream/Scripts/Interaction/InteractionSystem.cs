using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class InteractionSystem : MonoBehaviour
{
    public Rigidbody2D rb;
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
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;
    public Image examineImage;
    public TMP_Text examineText;
    public bool isExamining;
    public bool isGrabbing;

    [Header("Others")]
    //List of Picked Up items
    public List<GameObject> pickedItems = new List<GameObject>();

    void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                //Check if we are grabbing something, do not interact with other items, drop grabbed item first
                if (isGrabbing)
                {
                    GrabDrop();
                    return;
                }
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
            rb.velocity = Vector3.zero;
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

    public void GrabDrop()
    {
        //Check if we have grabbed object => drop item
        if (isGrabbing)
        {
            //make isGrabbing false
            isGrabbing = false;
            //Unparent the grabbed object
            grabbedObject.transform.parent = null;
            // set Y value to original position
            grabbedObject.transform.position = 
                new Vector3(grabbedObject.transform.position.x, grabbedObject.transform.position.y, grabbedObject.transform.position.z);
            grabbedObject.GetComponent<BoxCollider2D>().isTrigger = false;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
            //Null the grabbed object reference
            grabbedObject = null;
        }
        //Check if we have nothing grabbed, grab detected item
        else
        {
            //Enable isGrabbing Bool
            isGrabbing = true;

            //Assign grabbed object to object itself
            grabbedObject = detectedObject;

            //Parent grabbed object to player
            grabbedObject.transform.parent = transform;

            //Cache the y value of the object
            //grabbedObjectYValue = grabbedObject.transform.position.y;

            //Adjust the position of the grabbed object to be closer to hands
            grabbedObject.transform.localPosition = grabPoint.localPosition;

            grabbedObject.GetComponent<BoxCollider2D>().isTrigger = true;
            grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;

        }

    }

  
    
}
