using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class Item : MonoBehaviour
{

    //Interaction Type
    public enum InteractionType { NONE,PickUp,Examine}
    public InteractionType type;

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
                Debug.Log("Examine");
                break;
            default:
                Debug.Log("NULL ITEM");
                break;
        }
    }

}
