using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damge)
    {
        currentHealth = Mathf.Clamp(currentHealth - damge, 0, startingHealth);
        if(currentHealth > 0)
        {

        }
        else
        {

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            TakeDamage(1);
        }


    }

}
