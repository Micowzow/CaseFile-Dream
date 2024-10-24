using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDebug : MonoBehaviour
{
    public Image bButton;

    public Image xButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            BButton();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            XButton();
        }
    }

    public void XButton()
    {
        xButton.color = Color.red;
    }

    public void BButton()
    {
        bButton.color = Color.red;
    }
}
