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
        [SerializeField] private ScriptableStats _stats;
        private Rigidbody2D rb; //Rigidbody Componenet

        private CapsuleCollider2D col; //Capsuale Colliders

        private FrameInput frameInput; //Frame

        private Vector2 frameVelocity; //Movement per frame

        private bool cachedQueryStartInColliders;

        Animator animator;

        public bool facingRight = true;

        public bool isGrounded = false;

        public float speed; //Keep In case

        private CameraFollowObject cameraFollowObject;
        private float fallSpeedYDampingChangeThreshold;

        public Vector3 respawnPoint;
        


       

        #region Interface

        public Vector2 FrameInput => frameInput.Move;
        public event Action<bool, float> GroundedChanged;
        public event Action Jumped;

        #endregion

        private float _time;

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
            fallSpeedYDampingChangeThreshold = CameraManager.instance.fallSpeedYDampingChangeThreshold;
            respawnPoint = transform.position;
        }

        private void Update()
        {
            _time += Time.deltaTime;
            GatherInput();

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

            //If player is falling past a certain speed threshold
            if(rb.velocity.y < fallSpeedYDampingChangeThreshold && !CameraManager.instance.LerpedFromPlayerFalling)
            {
                CameraManager.instance.LerpingYDamping(true);
            }

            //if player is standing still or moving up
            if (rb.velocity.y >= 0f && !CameraManager.instance.IsLerpingYDamping && CameraManager.instance.LerpedFromPlayerFalling)
            {
                //reset so it can be called again
                CameraManager.instance.LerpedFromPlayerFalling = false;

                CameraManager.instance.LerpingYDamping(false);
            }

        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.tag == "Enemy")
            {
                transform.position = respawnPoint;
            }
            else if(collision.tag == "CheckPoint")
            {
                respawnPoint = transform.position;
            }

        }
        private void GatherInput() //Checking Player locaiton and movement Input
        {
            frameInput = new FrameInput //Frame movement
            {
                JumpDown = Input.GetButtonDown("Jump"), //If jump is pressed
                JumpHeld = Input.GetButton("Jump"), //If jump is held
                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) //Movement on Veritcal axis
            };

            if (_stats.SnapInput)
            {
                //Frame movement on Horizontal
                frameInput.Move.x = Mathf.Abs(frameInput.Move.x) < _stats.HorizontalDeadZoneThreshold ? 0 : Mathf.Sign(frameInput.Move.x); 
                //Frame movement on Vertical
                frameInput.Move.y = Mathf.Abs(frameInput.Move.y) < _stats.VerticalDeadZoneThreshold ? 0 : Mathf.Sign(frameInput.Move.y);
            }

            if (frameInput.JumpDown) //Checking if jump is pressed per frame
            {
                _jumpToConsume = true;
                _timeJumpWasPressed = _time;
            }
        }

        public void FixedUpdate() //Checking Methods
        {
            animator.SetFloat("yVelocity", rb.velocity.y);
            CheckCollisions();

            if(CanMove()==false)
                return;

            HandleJump();
            HandleGravity();
            
            ApplyMovement();
            

          
        }

        #region Collisions
        
        private float _frameLeftGrounded = float.MinValue;
        private bool _grounded; //Player grounded bool

        private void CheckCollisions() //Checking surface Collision
        {
            Physics2D.queriesStartInColliders = false;

            // Ground and Ceiling Checks
            bool groundHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.down, _stats.GrounderDistance, ~_stats.PlayerLayer);
            bool ceilingHit = Physics2D.CapsuleCast(col.bounds.center, col.size, col.direction, 0, Vector2.up, _stats.GrounderDistance, ~_stats.PlayerLayer);

            // Hit a Ceiling
            if (ceilingHit) frameVelocity.y = Mathf.Min(0, frameVelocity.y);

            // Landed on the Ground
            if (!_grounded && groundHit)
            {
                _grounded = true;
                animator.SetBool("isJumping", false);
                _coyoteUsable = true;
                _bufferedJumpUsable = true;
                _endedJumpEarly = false;
                GroundedChanged?.Invoke(true, Mathf.Abs(frameVelocity.y));
            }
            // Left the Ground
            else if (_grounded && !groundHit)
            {
                _grounded = false;
                animator.SetBool("isJumping", !_grounded);
                _frameLeftGrounded = _time;
                GroundedChanged?.Invoke(false, 0);
            }

            Physics2D.queriesStartInColliders = cachedQueryStartInColliders;
        }

        #endregion


        #region Jumping 

        private bool _jumpToConsume; //Is there a Jump to use
        private bool _bufferedJumpUsable; //Next Jump Queued for use
        private bool _endedJumpEarly; //was kump key release early
        private bool _coyoteUsable; //Jump usable for small amount of time after leaving surface
        private float _timeJumpWasPressed; //Jump key was Pressed


        private bool HasBufferedJump => _bufferedJumpUsable && _time < _timeJumpWasPressed + _stats.JumpBuffer; //Buffered Jump Is Queued
        private bool CanUseCoyote => _coyoteUsable && !_grounded && _time < _frameLeftGrounded + _stats.CoyoteTime; //Is Coyote Jump Available

        private void HandleJump() //Checking for Jump
        {
            if (!_endedJumpEarly && !_grounded && !frameInput.JumpHeld && rb.velocity.y > 0) _endedJumpEarly = true; //Ending jump when key released

            if (!_jumpToConsume && !HasBufferedJump) return; //If there is no jump to use and no Queud Jump DO NOT JUMP

            if (_grounded || CanUseCoyote) ExecuteJump(); //if grounded and is able to use jump Execute Jump Method

            _jumpToConsume = false;
        }

        public void ExecuteJump() //Perform Jump Action
        {

            _endedJumpEarly = false; //Button was not released early
            _timeJumpWasPressed = 0; //How many times was the jump pressed
            _bufferedJumpUsable = false; //The Buffered Jump Is not available for use
            _coyoteUsable = false; //Coyote Jump is not useable
            frameVelocity.y = _stats.JumpPower; //Frame movement 
            Jumped?.Invoke(); // Is jump command executed?
            
        }

        #endregion

        #region Horizontal

        private void HandleDirection() //Horizontal Movement
        {
            if (frameInput.Move.x == 0)
            {
                var deceleration = _grounded ? _stats.GroundDeceleration : _stats.AirDeceleration;
                frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, 0, deceleration * Time.fixedDeltaTime);
            }
            else
            {
                frameVelocity.x = Mathf.MoveTowards(frameVelocity.x, frameInput.Move.x * _stats.MaxSpeed, _stats.Acceleration * Time.fixedDeltaTime);
            }

            animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        }

        #endregion

        public void Flip()
        {
            facingRight = !facingRight; //if player is not facing right flip transform
            transform.Rotate(0f, 180f, 0f);
        }

        #region Gravity

        private void HandleGravity() //Gravity 
        {
            if (_grounded && frameVelocity.y <= 0f)
            {
                frameVelocity.y = _stats.GroundingForce;
            }
            else
            {
                var inAirGravity = _stats.FallAcceleration;
                if (_endedJumpEarly && frameVelocity.y > 0) inAirGravity *= _stats.JumpEndEarlyGravityModifier;
                frameVelocity.y = Mathf.MoveTowards(frameVelocity.y, -_stats.MaxFallSpeed, inAirGravity * Time.fixedDeltaTime);
            }
        }

        #endregion

        private void ApplyMovement() => rb.velocity = frameVelocity;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (_stats == null) Debug.LogWarning("Please assign a ScriptableStats asset to the Player Controller's Stats slot", this);
        }

        bool CanMove()
        {
            bool can = true;

            if (FindObjectOfType<InteractionSystem>().isExamining)
                can = false;

            return can;


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