using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Discovery : MonoBehaviour
{

    public TMP_Text locationName;

    public void SetName(string text)
    {
        locationName.text =  text;
    }

    public void DestroyUI()
    {
        GameObject.Destroy(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
