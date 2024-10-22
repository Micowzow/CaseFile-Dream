using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FadeText : MonoBehaviour
{

    public TMP_Text textBox;

    private float fadeTime;
    private bool fadingIn;
    // Start is called before the first frame update
    void Start()
    {
        textBox.CrossFadeAlpha(0, 0, false);
        fadeTime = 0;
        fadingIn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (fadingIn)
        {
            FadeIn();
        }
        else if(textBox.color.a != 0)
        {
            textBox.CrossFadeAlpha(0, 0.1f, false);
        }
    }

    void FadeIn()
    {
        textBox.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if(textBox.color.a == 1 && fadeTime > 2f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            fadingIn = true;
            
        }
    }

}
