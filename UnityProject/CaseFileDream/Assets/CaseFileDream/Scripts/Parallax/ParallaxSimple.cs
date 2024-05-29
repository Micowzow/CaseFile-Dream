using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxSimple : MonoBehaviour
{
    private float length, startposx;
    private float height, startposy;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startposx = transform.position.x;
        startposy = transform.position.y;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distX = (cam.transform.position.x * parallaxEffect);
        float distY = (cam.transform.position.y * parallaxEffect);

        transform.position = new Vector3(startposx + distX, startposy + distY, transform.position.z);
    }
}
