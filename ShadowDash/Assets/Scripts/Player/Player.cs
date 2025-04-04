using UnityEngine;

public class Player : Entity
{
    [Header("Move Info")]
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

    //private int facingDir = 1;
    //private bool isFacingRight = true;


    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
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

        if (Input.GetKeyDown(KeyCode.Mouse0) && isGrounded)
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

    protected override void CheckCollision()
    {
        base.CheckCollision();
    }

    private void HanldeAnimator()
    {
        isMoving = (rb.linearVelocityX != 0) ? true : false;

        animator.SetFloat("yVelocity", rb.linearVelocityY);
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetBool("isDashing", dashTime > 0);
        animator.SetBool("isAttacking", isAttacking);
        animator.SetInteger("comboCounter", comboCounter);
    }

}
