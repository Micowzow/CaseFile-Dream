using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class AddTime : MonoBehaviour
    {
        public TimerController timerController;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                timerController.AddTime();
                Destroy(gameObject);


            }
        }
    }
}

