
using UnityEngine.InputSystem;
using UnityEngine;
using Unity.Netcode;

namespace Leo{
    public class PlayerMovement : NetworkBehaviour
    {
        [SerializeField] private ScriptableStats stats;

        #region Components
        private Rigidbody2D rb;

        #endregion

        #region  Movement Variables
        private bool IsGrounded => Physics2D.OverlapBox(transform.position + stats.GroundCheckOffset, stats.GroundCheckSize, 0f, stats.GroundLayer);
        private bool InHangTime => hangBufferTimer > 0;
        private int jumpsLeft;

        private bool CanJump => (IsGrounded || InHangTime) && jumpsLeft > 0;

        private float jumpPressedBufferTimer;
        private float hangBufferTimer;

        #endregion

        #region Input
        private Vector2 directionInput;

        #endregion

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            CheckJumpsLeft();
            HandleBuffers();
            HandleGravity();
        
            Move();
        }

        
        private void CheckJumpsLeft(){
            if (IsGrounded) jumpsLeft = stats.JumpCount;
        }

        private void HandleGravity()
        {
            if (rb.velocity.y < stats.FallGravityThreshold && !IsGrounded)
            {
                rb.gravityScale = stats.FallGravityScale;
            }
            else rb.gravityScale = 1;
        }

        private void HandleBuffers()
        {
            if (IsGrounded){
                hangBufferTimer = stats.CoyoteTime;
            } else hangBufferTimer -= Time.deltaTime;

            if (jumpPressedBufferTimer > 0)
            {
                jumpPressedBufferTimer -= Time.deltaTime;
                Jump();
            }
        }


        private void Jump()
        {
            if (CanJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, stats.JumpPower);
                jumpPressedBufferTimer = 0;
                jumpsLeft--;
            }
        }

        private void Move()
        {
            rb.velocity = new Vector2(directionInput.x * stats.MovementSpeed, rb.velocity.y);
        }

        #region Input
        public void OnMove(InputAction.CallbackContext context)
        {
            if (!IsLocalPlayer) return;
            directionInput = context.ReadValue<Vector2>().normalized;
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!IsLocalPlayer) return;

            if (context.started)
            {
                Jump();
                jumpPressedBufferTimer = stats.JumpPressedBuffer;
            }
        }

        #endregion


        #region Gizmos

        void OnDrawGizmos()
        {

            if (IsGrounded)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.red;
            }
            Gizmos.DrawWireCube(transform.position + stats.GroundCheckOffset, stats.GroundCheckSize);
        }

        #endregion
    }
}
