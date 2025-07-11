
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
        private bool isGrounded;
        private bool canJump;
        private bool inHangTime;

        private float hangBufferTimer;

        #endregion

        #region Input

        private bool jumpInputPressed;
        private bool jumpInputReleased;
        private bool jumpInputHeld;

        private Vector2 directionInput;

        #endregion

        void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            CheckGrounded();
            HandleBuffers();
            HandleJump();
            HandleGravity();
        
            ApplyMovement();
        }

        private void CheckGrounded(){
            isGrounded = Physics2D.OverlapBox(transform.position + stats.GroundCheckOffset, stats.GroundCheckSize, 0f, stats.GroundLayer);
        }


        private void HandleGravity(){
            if (rb.velocity.y < stats.FallGravityThreshold && !isGrounded){
                rb.gravityScale = stats.FallGravityScale;
            } else rb.gravityScale = 1;
        }

        private void HandleBuffers()
        {
            if (isGrounded){
                hangBufferTimer = stats.CoyoteTime;
                return;
            }

            hangBufferTimer -= Time.deltaTime;
        }

        private void HandleJump(){
            if (isGrounded || hangBufferTimer > 0){
                canJump = true;
            } else canJump = false;

            if (jumpInputPressed && canJump){
                rb.velocity = new Vector2(rb.velocity.x, stats.JumpPower);
            }
        }

        private void ApplyMovement()
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
                Debug.Log("Jump Pressed");
                jumpInputPressed = true;
                jumpInputHeld = true;
            }
            else jumpInputPressed = false;
            
            if (context.canceled){
                jumpInputReleased = true;
                jumpInputHeld = false;
            } else jumpInputReleased = false;
        }

        #endregion


        #region Gizmos

        void OnDrawGizmos()
        {

            if (isGrounded)
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
