using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]

public class Examine : MonoBehaviour
{

    //Interaction Type
    public enum InteractionType { NONE,PickUp,Examine,GrabDrop }
    public InteractionType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Event")]
    public UnityEvent customEvent;

    //Collider Trigger
    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 9;
    }

    public void Interact()
    {
        switch (type)
        {
            case InteractionType.PickUp:
                //Add Object to the Picked Up Items List
                GameObject item = gameObject;
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                //Disable Object
                gameObject.SetActive(false);
                Debug.Log("PICK UP");
                break;
            case InteractionType.Examine:
                //Call the Examine item in the interaction system
                FindObjectOfType<ExamineSystem>().ExamineItem(this);
                Debug.Log("Examine");
                break;
            case InteractionType.GrabDrop:
                //Grab interaction
                FindObjectOfType<InteractionSystem>().GrabDrop();
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
        //call custom event(S)
        customEvent.Invoke();
    }

}
