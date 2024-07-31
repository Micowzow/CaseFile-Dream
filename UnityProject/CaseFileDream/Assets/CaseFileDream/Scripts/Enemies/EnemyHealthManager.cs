using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;
using UnityEngine.InputSystem;


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

    public bool enemyDead = false;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;




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
            if (Input.GetAxis("Fire3") ==1 && Vector2.Distance(enemy.position, playerAttackArea.position) < 2.5f && enemyDead == false)
            {
                TakeDamage(25);
                StartCoroutine(Vibrate());
            }

            cooldownTimer = cooldownTime;
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }

    }

    IEnumerator Vibrate()
    {
        GamePad.SetVibration(playerIndex, .1f, .1f);
        yield return new WaitForSeconds(.2f);
        GamePad.SetVibration(playerIndex, 0f, 0f);
        yield return new WaitForSeconds(.2f);
        GamePad.SetVibration(playerIndex, 0f, 0f);


    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        dazedTime = startDazedTime;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
            enemyDead = true;
            GamePad.SetVibration(playerIndex, 0f, 0f);
        }
        healthbar.SetCurrentHealth(currentHealth);
        GamePad.SetVibration(playerIndex, 0f, 0f);
    }

   

}
