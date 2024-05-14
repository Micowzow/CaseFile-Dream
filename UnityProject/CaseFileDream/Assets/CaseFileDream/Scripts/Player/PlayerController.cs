using System;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController
{
   
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class PlayerController : MonoBehaviour, IPlayerController
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
           
        

        #region Interface

        public Vector2 FrameInput => frameInput.Move;
        public event Action<bool, float> GroundedChanged;
        public event Action Jumped;

        #endregion

        private float time;

        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>(); //Call Rigidbody
            col = GetComponent<CapsuleCollider2D>(); //Call Capsule Collider

            cachedQueryStartInColliders = Physics2D.queriesStartInColliders;          
        }

        private void Start()
        {

        }

        private void Update()
        {
            time += Time.deltaTime;
            GatherInput();

            float move = Input.GetAxisRaw("Horizontal");


            HandleDirection();
                                
        }
               

        private void GatherInput() //Checking Player locaiton and movement Input
        {
            frameInput = new FrameInput //Frame movement
            {
                JumpDown = Input.GetButtonDown("Jump"), //If jump is pressed
                JumpHeld = Input.GetButton("Jump"), //If jump is held
                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) //Movement on Veritcal axis
            };

            if (stats.SnapInput)
            {
                //Frame movement on Horizontal
                frameInput.Move.x = Mathf.Abs(frameInput.Move.x) < stats.HorizontalDeadZoneThreshold ? 0 : Mathf.Sign(frameInput.Move.x); 
                //Frame movement on Vertical
                frameInput.Move.y = Mathf.Abs(frameInput.Move.y) < stats.VerticalDeadZoneThreshold ? 0 : Mathf.Sign(frameInput.Move.y);
            }

            if (frameInput.JumpDown) //Checking if jump is pressed per frame
            {
                jumpToConsume = true;
                timeJumpWasPressed = time;
            }
        }

        public void FixedUpdate() //Checking Methods
        {
            CheckCollisions();

            HandleJump();
            HandleGravity();
            
            ApplyMovement();

           

        }

        #region Collisions
        
        private float frameLeftGrounded = float.MinValue;
        private bool grounded; //Player grounded bool

        private void CheckCollisions() //Checking surface Collision
        {
            Physics2D.queriesStartInColliders = false;

            // Ground and Ceiling Checks
            bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.down, stats.GrounderDistance, ~stats.PlayerLayer);
            bool ceilingHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.up, stats.GrounderDistance, ~stats.PlayerLayer);

            // Hit a Ceiling
            if (ceilingHit) frameVelocity.y = Mathf.Min(0, frameVelocity.y);

            // Landed on the Ground
            if (!grounded && groundHit)
            {
                grounded = true;
                coyoteUsable = true;
                bufferedJumpUsable = true;
                endedJumpEarly = false;
                GroundedChanged?.Invoke(true, Mathf.Abs(frameVelocity.y));
            }
            // Left the Ground
            else if (grounded && !groundHit)
            {
                grounded = false;
                frameLeftGrounded = time;
                GroundedChanged?.Invoke(false, 0);
            }

            Physics2D.queriesStartInColliders = cachedQueryStartInColliders;
        }

        #endregion


        #region Jumping 

        private bool jumpToConsume; //Is there a Jump to use
        private bool bufferedJumpUsable; //Next Jump Queued for use
        private bool endedJumpEarly; //was kump key release early
        private bool coyoteUsable; //Jump usable for small amount of time after leaving surface
        private float timeJumpWasPressed; //Jump key was Pressed


        private bool HasBufferedJump => bufferedJumpUsable && time < timeJumpWasPressed + stats.JumpBuffer; //Buffered Jump Is Queued
        private bool CanUseCoyote => coyoteUsable && !grounded && time < frameLeftGrounded + stats.CoyoteTime; //Is Coyote Jump Available

        private void HandleJump() //Checking for Jump
        {
            if (!endedJumpEarly && !grounded && !frameInput.JumpHeld && rb.velocity.y > 0) endedJumpEarly = true; //Ending jump when key released

            if (!jumpToConsume && !HasBufferedJump) return; //If there is no jump to use and no Queud Jump DO NOT JUMP

            if (grounded || CanUseCoyote) ExecuteJump(); //if grounded and is able to use jump Execute Jump Method

            jumpToConsume = false;
        }

        public void ExecuteJump() //Perform Jump Action
        {

            endedJumpEarly = false; //Button was not released early
            timeJumpWasPressed = 0; //How many times was the jump pressed
            bufferedJumpUsable = false; //The Buffered Jump Is not available for use
            coyoteUsable = false; //Coyote Jump is not useable
            frameVelocity.y = stats.JumpPower; //Frame movement 
            Jumped?.Invoke(); // Is jump command executed?
            
        }

        #endregion

        #region Horizontal

        private void HandleDirection() //Horizontal Movement
        {
            if (frameInput.Move.x == 0)
            {
                var deceleration = grounded ? stats.GroundDeceleration : stats.AirDeceleration;
                frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, 0, deceleration * Time.fixedDeltaTime);
            }
            else
            {
                frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, frameInput.Move.x * stats.MaxSpeed, stats.Acceleration * Time.fixedDeltaTime);
            }

           
        }

        #endregion


        #region Gravity

        private void HandleGravity() //Gravity 
        {
            if (grounded && frameVelocity.y <= 0f)
            {
                frameVelocity.y = stats.GroundingForce;
            }
            else
            {
                var inAirGravity = stats.FallAcceleration;
                if (endedJumpEarly && frameVelocity.y > 0) inAirGravity *= stats.JumpEndEarlyGravityModifier;
                frameVelocity.y = Mathf.MoveTowards(frameVelocity.y, -stats.MaxFallSpeed, inAirGravity * Time.fixedDeltaTime);
            }
        }

        #endregion

        private void ApplyMovement() => rb.velocity = frameVelocity;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (stats == null) Debug.LogWarning("Please assign a ScriptableStats asset to the Player Controller's Stats slot", this);
        }

    
#endif
    }

    

    

    public struct FrameInput
    {
        public bool JumpDown; //is Jump button pressed on frame
        public bool JumpHeld; //Is Jump button being held
        public Vector2 Move; // Movement on axis
    }

    public interface IPlayerController
    {
        public event Action<bool, float> GroundedChanged;

        public event Action Jumped;
        public Vector2 FrameInput { get; }
    }
}