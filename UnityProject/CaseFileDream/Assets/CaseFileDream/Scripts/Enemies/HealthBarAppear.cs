using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarAppear : MonoBehaviour
{
    public Canvas enemyHealthCanvas;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealthCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyHealthCanvas.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            enemyHealthCanvas.enabled = false;
        }
    }
}
