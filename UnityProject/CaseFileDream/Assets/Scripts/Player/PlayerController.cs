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
        private Rigidbody2D _rb; //Rigidbody Componenet

        private CapsuleCollider2D _col; //Capsuale Colliders

        private FrameInput _frameInput; //Frame

        private Vector2 _frameVelocity; //Movement per frame

        private bool _cachedQueryStartInColliders;

        Animator animator;

        public bool facingRight = true;

        public float speed;

        private CameraFollowObject cameraFollowObject;

       

        #region Interface

        public Vector2 FrameInput => _frameInput.Move;
        public event Action<bool, float> GroundedChanged;
        public event Action Jumped;

        #endregion

        private float _time;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>(); //Call Rigidbody
            _col = GetComponent<CapsuleCollider2D>(); //Call Capsule Collider

            _cachedQueryStartInColliders = Physics2D.queriesStartInColliders;
            animator = GetComponent<Animator>();
        }

        private void Start()
        {
            cameraFollowObject = cameraFollowGo.GetComponent<CameraFollowObject>();
        }

        private void Update()
        {
            _time += Time.deltaTime;
            GatherInput();

            float move = Input.GetAxisRaw("Horizontal");

            _rb.velocity = new Vector2(move * speed, _rb.velocity.y);

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

        private void GatherInput() //Checking Player locaiton and movement Input
        {
            _frameInput = new FrameInput //Frame movement
            {
                JumpDown = Input.GetButtonDown("Jump"), //If jump is pressed
                JumpHeld = Input.GetButton("Jump"), //If jump is held
                Move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) //Movement on Veritcal axis
            };

            if (_stats.SnapInput)
            {
                //Frame movement on Horizontal
                _frameInput.Move.x = Mathf.Abs(_frameInput.Move.x) < _stats.HorizontalDeadZoneThreshold ? 0 : Mathf.Sign(_frameInput.Move.x); 
                //Frame movement on Vertical
                _frameInput.Move.y = Mathf.Abs(_frameInput.Move.y) < _stats.VerticalDeadZoneThreshold ? 0 : Mathf.Sign(_frameInput.Move.y);
            }

            if (_frameInput.JumpDown) //Checking if jump is pressed per frame
            {
                _jumpToConsume = true;
                _timeJumpWasPressed = _time;
            }
        }

        public void FixedUpdate() //Checking Methods
        {

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
            bool groundHit = Physics2D.CapsuleCast(_col.bounds.center, _col.size, _col.direction, 0, Vector2.down, _stats.GrounderDistance, ~_stats.PlayerLayer);
            bool ceilingHit = Physics2D.CapsuleCast(_col.bounds.center, _col.size, _col.direction, 0, Vector2.up, _stats.GrounderDistance, ~_stats.PlayerLayer);

            // Hit a Ceiling
            if (ceilingHit) _frameVelocity.y = Mathf.Min(0, _frameVelocity.y);

            // Landed on the Ground
            if (!_grounded && groundHit)
            {
                _grounded = true;
                _coyoteUsable = true;
                _bufferedJumpUsable = true;
                _endedJumpEarly = false;
                GroundedChanged?.Invoke(true, Mathf.Abs(_frameVelocity.y));
            }
            // Left the Ground
            else if (_grounded && !groundHit)
            {
                _grounded = false;
                _frameLeftGrounded = _time;
                GroundedChanged?.Invoke(false, 0);
            }

            Physics2D.queriesStartInColliders = _cachedQueryStartInColliders;
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
            if (!_endedJumpEarly && !_grounded && !_frameInput.JumpHeld && _rb.velocity.y > 0) _endedJumpEarly = true; //Ending jump when key released

            if (!_jumpToConsume && !HasBufferedJump) return; //If there is no jump to use and no Queud Jump DO NOT JUMP

            if (_grounded || CanUseCoyote) ExecuteJump(); //if grounded and is able to use jump Execute Jump Method

            _jumpToConsume = false;
        }

        private void ExecuteJump() //Perform Jump Action
        {
            _endedJumpEarly = false; //Button was not released early
            _timeJumpWasPressed = 0; //How many times was the jump pressed
            _bufferedJumpUsable = false; //The Buffered Jump Is not available for use
            _coyoteUsable = false; //Coyote Jump is not useable
            _frameVelocity.y = _stats.JumpPower; //Frame movement 
            Jumped?.Invoke(); // Is jump command executed?
        }

        #endregion

        #region Horizontal

        private void HandleDirection() //Horizontal Movement
        {
            if (_frameInput.Move.x == 0)
            {
                var deceleration = _grounded ? _stats.GroundDeceleration : _stats.AirDeceleration;
                _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, 0, deceleration * Time.fixedDeltaTime);
            }
            else
            {
                _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, _frameInput.Move.x * _stats.MaxSpeed, _stats.Acceleration * Time.fixedDeltaTime);
            }

            animator.SetFloat("xVelocity", Mathf.Abs(_rb.velocity.x));
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
            if (_grounded && _frameVelocity.y <= 0f)
            {
                _frameVelocity.y = _stats.GroundingForce;
            }
            else
            {
                var inAirGravity = _stats.FallAcceleration;
                if (_endedJumpEarly && _frameVelocity.y > 0) inAirGravity *= _stats.JumpEndEarlyGravityModifier;
                _frameVelocity.y = Mathf.MoveTowards(_frameVelocity.y, -_stats.MaxFallSpeed, inAirGravity * Time.fixedDeltaTime);
            }
        }

        #endregion

        private void ApplyMovement() => _rb.velocity = _frameVelocity;

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