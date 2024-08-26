using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnewayPlatform : MonoBehaviour
{
    private GameObject currentOneWayPlatform;

    public Collider2D playerCollider;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (currentOneWayPlatform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if( collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = collision.gameObject;

        }
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        if( collision.gameObject.CompareTag("OneWayPlatform"))
        {
            currentOneWayPlatform = null;

        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentOneWayPlatform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(playerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(playerCollider, platformCollider, false);

    }
}
