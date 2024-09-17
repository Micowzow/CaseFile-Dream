using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrambleWall : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Scissors" && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("CutBramble");
            Destroy(gameObject);
        }
    }
}
