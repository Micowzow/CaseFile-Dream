using UnityEngine;




public class AudioChanger : MonoBehaviour
{

   
    

    void Start()
    { 
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        { // only an object tagged Player stops the sound
            FindObjectOfType<AudioManager>().Play("TreeTopMusic");
            FindObjectOfType<AudioManager>().Stop("Music");

            Debug.Log("Player entered!");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    //use ontriggerexit 2D instead of no 2D because of collider

    {
        if (other.tag == "Player")
        { // only an object tagged Player restarts the sound

            FindObjectOfType<AudioManager>().Stop("TreeTopMusic");
            FindObjectOfType<AudioManager>().Play("Music");
            Debug.Log("Player exit!");
        }
    }
}