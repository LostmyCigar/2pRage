using Unity.Netcode;
using UnityEngine;

public class PlayerStomp : NetworkBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private ScriptableStats stats;

    private void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsOwner || !collision.CompareTag("Player")) return;

        if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, stats.JumpPower);
            // Apply a force to the collided player
            Rigidbody2D otherRb = collision.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                Vector2 stompForce = new Vector2(0, stats.JumpPower / 2);
                otherRb.AddForce(stompForce, ForceMode2D.Impulse);
            }
        }
    }
}
