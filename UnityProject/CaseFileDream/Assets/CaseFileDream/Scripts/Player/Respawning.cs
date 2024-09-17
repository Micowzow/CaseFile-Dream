using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PlayerController
{
    public class Respawning : MonoBehaviour
    {
        public Vector2 checkpointPos;
        Rigidbody2D playerRb;
        public Animator anim;

        public PlayerHealth playerHealth;

        public void Awake()
        {
            playerRb = GetComponent<Rigidbody2D>();
        }
        // Start is called before the first frame update
        void Start()
        {

            checkpointPos = transform.position;

        }

        // Update is called once per frame
        void Update()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Enemy")
            {
                if (playerHealth.currentHealth > 0)
                {
                    playerHealth.TakeDamage(1);
                }
                if (playerHealth.currentHealth <= 0)
                {
                    anim.Play("FadeOut");
                    Die();
                }

            }

            if (collision.tag == "Water")
            {
                
                if (playerHealth.currentHealth <= 0)
                {
                    anim.Play("FadeOut");
                    Die();
                }

            }


        }

        public void UpdateCheckpoint(Vector2 pos)
        {
            checkpointPos = pos;
        }
        public void Die()
        {

            StartCoroutine(Respawn(1.5f));

        }

        IEnumerator Respawn(float duration)
        {
            playerRb.simulated = false;
            playerRb.velocity = new Vector2(0, 0);
            transform.localScale = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(duration);
            transform.position = checkpointPos;
            transform.localScale = new Vector3(1, 1, 1);
            playerRb.simulated = true;
            playerHealth.currentHealth = playerHealth.startingHealth;

        }
    }
}
