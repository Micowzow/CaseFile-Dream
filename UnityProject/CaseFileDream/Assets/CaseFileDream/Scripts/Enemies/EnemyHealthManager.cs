using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public EnemyHealthBar healthbar;

    private float dazedTime;
    public float startDazedTime;
    
    public Transform enemy;
    public Transform playerAttackArea;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

   


    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        
    }

    public void Update()
    {
        if(dazedTime <= 0)
        {
            GetComponent<EnemyController>().speed = 5;
        }
        else
        {
            GetComponent<EnemyController>().speed = 0;
            dazedTime -= Time.deltaTime;
        }
        if (cooldownTimer <= 0)
        {
            if (Input.GetKeyDown(KeyCode.F) && Vector2.Distance(enemy.position, playerAttackArea.position) < 2.5f)
            {
                TakeDamage(25);
            }

            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        dazedTime = startDazedTime;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        healthbar.SetCurrentHealth(currentHealth);
    }
}
