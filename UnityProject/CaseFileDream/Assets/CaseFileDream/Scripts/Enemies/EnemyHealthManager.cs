using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using XInputDotNetPure;


public class EnemyHealthManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public EnemyHealthBar healthbar;

    public SpriteRenderer spriteRenderer;

    public EssenceDrop essenceDrop;

    private float dazedTime;
    public float startDazedTime;
    
    public Transform enemy;
    public Transform playerAttackArea;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    public bool enemyDead = false;

    public ParticleSystem pS;

    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;




    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        essenceDrop = GetComponent<EssenceDrop>();
        pS.Stop();
        
    }

    public void Update()
    {
        if(dazedTime <= 0)
        {
            //GetComponent<EnemyController>().speed = 5;
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
                
            }

            cooldownTimer = cooldownTime;

            if (Input.GetAxis("Fire3") == 1)
            {
                StartCoroutine(Vibrate());
            }


        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }

    }

    IEnumerator Vibrate()
    {
        GamePad.SetVibration(playerIndex, .1f, .1f);
        yield return new WaitForSeconds(.1f);
        GamePad.SetVibration(playerIndex, 0f, 0f);
       
    }

    IEnumerator Death()
    {
        pS.Play();
        essenceDrop.DropEssence();
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
        enemyDead = true;
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        dazedTime = startDazedTime;
        FindObjectOfType<AudioManager>().Play("EnemyDamage");
        if (currentHealth <= 0)
        {
            StartCoroutine(Death());
            
        }
        healthbar.SetCurrentHealth(currentHealth);
        
    }

    



}
