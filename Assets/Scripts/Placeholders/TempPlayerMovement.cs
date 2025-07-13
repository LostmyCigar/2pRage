using UnityEngine;
using Unity.Netcode;
public class TempPlayerMovement : NetworkBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;
    private float jumpForce = 10f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!IsOwner) return;

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new(moveInput * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new(rb.velocity.x, jumpForce);
        }
    }

}
