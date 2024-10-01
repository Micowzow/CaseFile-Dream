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
    
    public GameObject grabbedObject;
    public float grabbedObjectYValue;
    public Transform grabPoint;
   
    
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
                detectedObject.GetComponent<Item>().Interact();
                //Check if we are grabbing something, do not interact with other items, drop grabbed item first
                if (isGrabbing)
                {
                    //GrabDrop();
                    //return;
                }
                
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
        return Input.GetButtonDown("Fire1");

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

            FindObjectOfType<AudioManager>().Play("Drop");
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

            FindObjectOfType<AudioManager>().Play("PickUp");

        }

    }

  
    
}
