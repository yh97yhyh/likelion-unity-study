using UnityEngine;

public class EnemySkeleton : Entity
{
    bool isAttacking;

    [Header("Move Info")]
    [SerializeField]
    private float moveSpeed;

    [Header("Player Derection")]
    [SerializeField]
    private float playerCheckDistance;
    [SerializeField]
    private LayerMask whatIsPlayer;

    private RaycastHit2D isPlayerDetected;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

        MoveEnemySkeleton();
        HandlePlayerDerection();
    }

    protected override void CheckCollision()
    {
        base.CheckCollision();
        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);

        if (!isGrounded || isWallDetected)
        {
            Flip();
        }
    }

    private void MoveEnemySkeleton()
    {
        if (!isAttacking)
        {
            rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocityY);
        }
    }

    private void HandlePlayerDerection()
    {
        if (!isAttacking)
        {
            rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocityY);
        }

        if (isPlayerDetected)
        {
            if (isPlayerDetected.distance > 1)
            {
                // 추적
                rb.linearVelocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.linearVelocityY);
                isAttacking = false;
                Debug.Log("Enemy : 플레이어 감지");
            }
            else
            {
                isAttacking = true;
                Debug.Log($"Enemy : 공격! {isPlayerDetected.collider.gameObject.name}");
            }
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));
    }
}
