using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AttackArea : MonoBehaviour
{
    private int damage = 5;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Enemy") && (Input.GetAxis("Fire3") == 1) && collider.GetComponent<EnemyHealthManager>() != null)
        {
            EnemyHealthManager enemyhealth = collider.GetComponent<EnemyHealthManager>();
            enemyhealth.TakeDamage(damage);
        }
    }
}
