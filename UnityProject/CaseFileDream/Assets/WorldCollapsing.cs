using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
namespace PlayerController
{ 
public class WorldCollapsing : MonoBehaviour
{
    public TimerController timerController;
     

        public ParticleSystem corruptionOne;
        public ParticleSystem corruptionTwo;
        public ParticleSystem corruptionThree;
        public ParticleSystem corruptionFour;
        public Light2D corruptionLight;
    void Start()
    {
            corruptionLight.enabled = false;
        }

    // Update is called once per frame
    void Update()
    {
            if (timerController.timeRemaining <= 600)
            {
                corruptionOne.Play();
                corruptionTwo.Play();
                corruptionThree.Play();
                corruptionFour.Play();
                corruptionLight.enabled = true;
            }
            else
            {
                corruptionOne.Stop();
                corruptionTwo.Stop();
                corruptionThree.Stop();
                corruptionFour.Stop();
                corruptionLight.enabled = false;
            }
        }
} 

}
