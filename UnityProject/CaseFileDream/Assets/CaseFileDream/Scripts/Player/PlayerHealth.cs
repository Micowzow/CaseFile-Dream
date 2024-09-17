using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class PlayerHealth : MonoBehaviour
{
    public float startingHealth;
    public float currentHealth;
    public PlayerExtra playerExtra;
    private void Awake()
    {
        currentHealth = startingHealth;
            playerExtra = GetComponent<PlayerExtra>();

    }

    public void TakeDamage(float damge)
    {
        currentHealth = Mathf.Clamp(currentHealth - damge, 0, startingHealth);
        if (currentHealth > 0)
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
            TakeDamage(0);
        }

        if (collision.tag == "Water")
        {
                if (playerExtra.hasBubblePower == false)
                {
                    TakeDamage(10);

                }
                else
                {
                    TakeDamage(0);
                }
                
        }

    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

} 
}
