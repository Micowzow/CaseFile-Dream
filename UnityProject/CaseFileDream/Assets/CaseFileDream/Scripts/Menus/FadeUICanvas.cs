using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUICanvas : MonoBehaviour
{
    public Image Image;

    private float fadeTime;
    private bool fadingIn;
    // Start is called before the first frame update
    void Start()
    {
        Image.CrossFadeAlpha(0, 0, false);
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
        else if (Image.color.a != 0)
        {
            Image.CrossFadeAlpha(0, 0.5f, false);
        }
    }

    void FadeIn()
    {
        Image.CrossFadeAlpha(1, 0.5f, false);
        fadeTime += Time.deltaTime;
        if (Image.color.a == 1 && fadeTime > 3f)
        {
            fadingIn = false;
            fadeTime = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            fadingIn = true;

        }
    }
}
