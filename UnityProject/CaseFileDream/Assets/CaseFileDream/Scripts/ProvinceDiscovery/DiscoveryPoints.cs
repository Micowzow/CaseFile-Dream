using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryPoints : MonoBehaviour
{

    public string locationName;
    public GameObject ProvinceTitles;
    bool isDone = false;

    void SpawnDiscoveryUI()
    {
        GameObject go = Instantiate(ProvinceTitles);
        go.GetComponent<Discovery>().SetName(locationName);
        isDone = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Player" && !isDone)
        {
            SpawnDiscoveryUI();
        }
    }
    
}
