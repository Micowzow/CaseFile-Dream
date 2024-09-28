using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    public Transform attackOrigin;
    public float attackRadius = 1f;
    public LayerMask enemyMask;

    public float cooldownTime = .5f;
    private float cooldownTimer = 0f;

    public int attackDamage = 25;

    public Animator animator;

    private void Update()
    {
        if (cooldownTimer <= 0)
        {
            if (Input.GetAxis("Fire3") == 1)
            {
                // Example of playing attack animation
                StartCoroutine(AttackAnim());

                Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackOrigin.position, attackRadius, enemyMask);
                foreach (var enemy in enemiesInRange)
                {
                    enemy.GetComponent<EnemyHealthManager>().TakeDamage(attackDamage);
                }

                cooldownTimer = cooldownTime;
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    IEnumerator AttackAnim()
    {
        animator.SetBool("isAttacking", true);
        yield return new WaitForSeconds(.1f);
        animator.SetBool("isAttacking", false);
        
    }

        private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackOrigin.position, attackRadius);
    }
}
