using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField]
    private float moveSpeed = 5f;
    [SerializeField]
    private float jumpForce = 7f;

    [Header("Dash Info")]
    [SerializeField]
    private float dashSpeed;
    [SerializeField]
    private float dashDuration;
    // [SerializeField]
    private float dashTime;
    [SerializeField]
    private float dashCooldown;
    // [SerializeField]
    private float dashCooldownTimer;

    [Header("Attack Info")]
    [SerializeField]
    private float comboTime = 0.3f;
    private float comboTimeCounter;
    private bool isAttacking;
    private int comboCounter;

    private float xInput;
    [SerializeField]
    private bool isMoving = false;

    private int facingDir = 1;
    private bool isFacingRight = true;

    [Header("Collision Info")]
    [SerializeField]
    private float grouncCheckDistance;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        CheckGround();
        MovePlayer();
        Attack();
        HanldeAnimator();
    }

    private void MovePlayer()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        HandleDash();

        if (isAttacking)
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
        else if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(xInput * dashSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * moveSpeed, rb.linearVelocityY);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpForce);
        }

        if (rb.linearVelocityX > 0 && !isFacingRight)
        {
            Flip();
        }
        else if (rb.linearVelocityX < 0 && isFacingRight)
        {
            Flip();
        }
    }

    private void Attack()
    {
        comboTimeCounter -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGround)
        {
            isAttacking = true;
            comboTimeCounter = comboTime;
        }
    }

    public void FinishAttack()
    {
        isAttacking = false;

        comboCounter++;

        if (comboCounter > 2)
        {
            comboCounter = 0;
        }

        if (comboTimeCounter < 0)
        {
            comboCounter = 0;
        }
    }

    private void HandleDash()
    {
        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer < 0)
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }

    private void HanldeAnimator()
    {
        isMoving = (rb.linearVelocityX != 0) ? true : false;

        animator.SetFloat("yVelocity", rb.linearVelocityY);
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGround);
        animator.SetBool("isDashing", dashTime > 0);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetInteger("comboCounter", comboCounter);
    }

    private void Flip()
    {
        facingDir = facingDir * -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }

    private void CheckGround()
    {
        isGround = Physics2D.Raycast(transform.position, Vector2.down, grouncCheckDistance, whatIsGround);
        Debug.Log(isGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - grouncCheckDistance));
    }
}
