using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class ExamineSystem : MonoBehaviour
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

    

    void Update()
    {
        if(DetectObject())
        {
            if(InteractInput())
            {
                detectedObject.GetComponent<Examine>().Interact();
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
        return Input.GetButtonDown("Fire2");

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


    public void ExamineItem(Examine item)
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
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (isExamining)
        {
            //Hide examine window
            examineWindow.SetActive(false);
            //disable the boolean
            isExamining = false;
        }
    }

    

  
    
}
