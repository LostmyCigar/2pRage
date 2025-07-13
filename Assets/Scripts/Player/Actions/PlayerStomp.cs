using System;
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

    public void StompOtherPlayer(GameObject stompedPlayer)
    {
        if (!IsOwner) return;

        Rigidbody2D otherRb = stompedPlayer.GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(rb.velocity.x, stats.JumpPower);

        if (otherRb)
            otherRb.velocity = new Vector2(otherRb.velocity.x, -(stats.JumpPower/2));
    }
}
