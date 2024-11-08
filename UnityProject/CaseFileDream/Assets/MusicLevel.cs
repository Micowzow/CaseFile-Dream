using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        FindObjectOfType<AudioManager>().Play("Music");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
