using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeaconInteraction : MonoBehaviour
{
    public Transform player;
    public Transform beacon;
    public ParticleSystem pS;
    // Start is called before the first frame update
    void Start()
    {
        pS.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(player.position, beacon.position) < 2.5f)
        {
            BeaconOn();
        }
    }

    public void BeaconOn()
    {
        pS.Play();
    }
}
