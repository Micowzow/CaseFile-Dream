using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
    public class CameraFollowObject : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private Transform playerTransform;

        [Header("Flip Rotation Stats")]
        [SerializeField] private float flipRotatioTime = 0.5f;

        private Coroutine turnCoroutine;

        private PlayerController player;

        private PlayerExtra playerExtra;

        private bool isfacingRight;

        private void Awake()
        {
            playerExtra = playerTransform.gameObject.GetComponent<PlayerExtra>();

            isfacingRight = playerExtra.facingRight;
        }

        private void Update()
        {
            transform.position = playerTransform.position;
        }

        public void CallTurn()
        {
            // turnCoroutine = StartCoroutine(FlipYLerp());

            LeanTween.rotateY(gameObject, DetermineEndRotation(), flipRotatioTime).setEaseInOutSine();
        }

        private IEnumerator FlipYLerp()
        {
            float startRotation = transform.localEulerAngles.y;
            float endRotationAmount = DetermineEndRotation();
            float yRotation = 0f;

            float elapsedTime = 0f;
            while(elapsedTime < flipRotatioTime)
            {
                elapsedTime += Time.deltaTime;

                yRotation = Mathf.Lerp(startRotation, endRotationAmount, (elapsedTime / flipRotatioTime));
                transform.rotation = Quaternion.Euler(0f, yRotation, 0f);

                yield return null;
            }

            
        }

        private float DetermineEndRotation()
        {
            isfacingRight = !isfacingRight;

            if (isfacingRight)
            {
                return 0f;
            }

            else
            {
                return 180f;
            }
        }

    }
}
