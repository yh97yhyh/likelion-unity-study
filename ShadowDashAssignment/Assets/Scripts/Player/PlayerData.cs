using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]

public class PlayerData : ScriptableObject
{
    [Header("Move Info")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Dash Info")]
    public float dashSpeed = 15f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;

    [Header("Attack Info")]
    public float comboTime = 0.3f;

    [Header("Collision Info")]
    public float groundCheckDistance = 0.5f;
    public LayerMask whatIsGround;
}