using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
   
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerExtra : MonoBehaviour, IDataPersistance
    {
        [Header("Camera")]
        [SerializeField] private GameObject cameraFollowGo;

        //Components for scriptable assets
        [SerializeField] private ScriptableStats stats;
        private Rigidbody2D rb; //Rigidbody Componenet

        private CapsuleCollider2D col; //Capsuale Colliders

        private FrameInput frameInput; //Frame

        private Vector2 frameVelocity; //Movement per frame

        private bool cachedQueryStartInColliders;

        Animator animator;

        public bool facingRight = true;

        public float speed; //Keep In case

        private CameraFollowObject cameraFollowObject;
        private float fallSpeedYDampingChangeThreshold;

        public Vector3 respawnPoint;

        public Rigidbody2D platform;

        
        private float time;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>(); //Call Rigidbody
            col = GetComponent<CapsuleCollider2D>(); //Call Capsule Collider

            cachedQueryStartInColliders = Physics2D.queriesStartInColliders;
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            cameraFollowObject = cameraFollowGo.GetComponent<CameraFollowObject>();
           
            respawnPoint = transform.position;
        }

        public void LoadData(GameData data)
        {
            this.transform.position = data.playerPosition;
        }

        public void SaveData( ref GameData data)
        {
            data.playerPosition = this.transform.position;
        }

        private void Update()
        {

            float move = Input.GetAxisRaw("Horizontal");

            //rb.velocity = new Vector2(move * speed, rb.velocity.y); //Can't remember what this was for?

            HandleDirection();

            if (move < 0 && facingRight)
            {
                Flip();
                cameraFollowObject.CallTurn();
            }
            else if(move>0 && !facingRight)
            {
                Flip();
                cameraFollowObject.CallTurn();
            }

            
           

        }
        

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("MovingPlatform"))
            {
                transform.parent = collision.transform;
                platform = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.gravityScale = 10;
            }
            if (collision.gameObject.CompareTag("LanternInteract"))
            {
                transform.parent = collision.transform;
                platform = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.gravityScale = 10;
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("MovingPlatform"))
            {
                transform.parent = null;
                platform = null;
                rb.gravityScale = 0f;
            }
            if (collision.gameObject.CompareTag("LanternInteract"))
            {
                transform.parent = null;
                platform = null;
                rb.gravityScale = 0;
            }
        }

       
        public void FixedUpdate() //Checking Methods
        {
            animator.SetFloat("yVelocity", rb.velocity.y);


            //if(CanMove()==false)
            //   return;

        }

        #region Collisions        
        private bool grounded; //Player grounded bool

        private void CheckCollisions() //Checking surface Collision
        {
            // Ground and Ceiling Checks
            bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.down, stats.GrounderDistance, ~stats.PlayerLayer);
            bool ceilingHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.up, stats.GrounderDistance, ~stats.PlayerLayer);

            // Hit a Ceiling
            if (ceilingHit) frameVelocity.y = Mathf.Min(0, frameVelocity.y);

            // Landed on the Ground
            if (!grounded && groundHit)
            {                
                animator.SetBool("isJumping", false);               
            }
            // Left the Ground
            else if (grounded && !groundHit)
            {         
                animator.SetBool("isJumping", !grounded);             
            }          
        }

        #endregion



        #region Horizontal

        private void HandleDirection() //Horizontal Movement
        {       

            animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        }

        #endregion

        public void Flip()
        {
            facingRight = !facingRight; //if player is not facing right flip transform
            transform.Rotate(0f, 180f, 0f);
        }


        bool CanMove()
        {
            bool can = true;

            if (FindObjectOfType<ExamineSystem>().isExamining)
                can = false;

            return can;

        }
    }

    

    

   
}