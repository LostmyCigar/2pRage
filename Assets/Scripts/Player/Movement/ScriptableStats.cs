using Unity.VisualScripting;
using UnityEngine;

 [CreateAssetMenu]
public class ScriptableStats : ScriptableObject
{

    [Header("LAYERS")] [Tooltip("Set this to the layer your player is on")]
    public LayerMask GroundLayer;
    public LayerMask PlayerLayer;
    
    [Header("Ground Check Settings")]
    public Vector3 GroundCheckOffset = new Vector3(0f, -0.1f, 0f);
    public Vector3 GroundCheckSize = new Vector3(0f, -0.1f, 0f);

    [Header("Movement Settings")]
    public float MovementSpeed = 14f;


    [Header("InAir Settings")]
    public float FallGravityThreshold = 0.1f;
    public float FallGravityScale = 2f;


    [Header("Buffers")]
    public float CoyoteTime = .15f;
    public float JumpPressedBuffer = .15f;


    [Header("JUMP")]

    [Tooltip("The immediate velocity applied when jumping")]
    public float JumpPower = 36;

    [Tooltip("How many jumps the player can perform before touching the ground again")]
    public int JumpCount = 1;

}