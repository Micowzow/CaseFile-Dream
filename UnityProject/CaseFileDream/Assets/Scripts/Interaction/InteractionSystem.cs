using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [Header("Detection Parameters")]
    //Detection Point
    public Transform detectionPoint;

    //Detection Radius
    private const float detectionRadius=0.2f;

    //Detection Layer
    public LayerMask detectionLayer;

    //Cached Trigger Object
    public GameObject detectedObject;

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionPoint.position, detectionRadius);
    }
}
