using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class Checkpoint : MonoBehaviour
    {
        Respawning respawning;
        LanternRespawn lanternRespawn;
        // Start is called before the first frame update
        void Awake()
        {
            respawning = GameObject.FindGameObjectWithTag("Player").GetComponent<Respawning>();
            lanternRespawn = GameObject.FindGameObjectWithTag("Lantern").GetComponent<LanternRespawn>();
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                respawning.UpdateCheckpoint(transform.position);
            }
            if (collision.CompareTag("Player"))
            {
                lanternRespawn.UpdateCheckpoint(transform.position);
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}
