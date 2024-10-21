using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidRotate : MonoBehaviour
{

    public float speed = 10;

    public SpriteRenderer squid;
    private int dir = 1;
    public bool flipY = false;
    // Start is called before the first frame update
    void Start()
    {
        if (flipY == true)
        {
            squid.flipY = true;
            dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed*dir);
    }
}
