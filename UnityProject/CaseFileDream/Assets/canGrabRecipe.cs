using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class canGrabRecipe : MonoBehaviour
{
    public Transform mallet;
    public Transform recipe;

    public BoxCollider2D perfumeRecipe;
    public Rigidbody2D rb;

    public SpriteRenderer glass;
    // Start is called before the first frame update
    void Start()
    {
        perfumeRecipe.enabled = false;
        rb.isKinematic = true;
        glass.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BreakGlass()
    {
        if(Vector2.Distance(mallet.position, recipe.position) < 2.5f)

        {
            perfumeRecipe.enabled = true;
            rb.isKinematic = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Mallet")

        {
            perfumeRecipe.enabled = true;
            rb.isKinematic = false;
            glass.enabled = false;
        }
    }
}
