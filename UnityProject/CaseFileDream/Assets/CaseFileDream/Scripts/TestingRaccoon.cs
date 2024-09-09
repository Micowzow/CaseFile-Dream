using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestingRaccoon : MonoBehaviour
{
    public GameObject bubble;
    public EssenceManager essenceManager;

    public bool hasBubble = false;

    public TextMeshProUGUI essenceDisplay;

    public int bubbleAmount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && essenceManager.essences == bubbleAmount && hasBubble == false)
        {
            Debug.Log("Spaw Bubble");
            Instantiate(bubble);
            hasBubble = true;
            essenceManager.essences -= bubbleAmount;
            essenceDisplay.text = essenceManager.essences.ToString();
        }
    }
}
