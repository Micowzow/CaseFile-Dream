using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlash : MonoBehaviour
{
    

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    

    public Animator animator;

    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetAxis("Fire3") == 1)
            {
                // Example of playing attack animation
                StartCoroutine(AttackAnim());

            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    IEnumerator AttackAnim()
    {
        
        animator.SetBool("isSlashing", true);
        yield return new WaitForSeconds(.1f);
        
        animator.SetBool("isSlashing", false);
    }

    
}
