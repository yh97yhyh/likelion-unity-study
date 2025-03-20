using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpUp = 1;
    public Vector3 direction;

    Animator animator;
    Rigidbody2D rigid2D;
    SpriteRenderer sp;
    public GameObject slash;

    public bool isJump = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        direction = Vector2.zero;
    }

    void Update()
    {
        FlipPlayer();
        Move();
        Jump();
        Attack();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void FlipPlayer()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        if (direction.x < 0)
        {
            sp.flipX = true;
            animator.SetBool("isRun", true);
        }
        else if (direction.x > 0)
        {
            sp.flipX = false;
            animator.SetBool("isRun", true);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
    }

    private void Move()
    {
        transform.position += direction * speed * Time.deltaTime;        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && !animator.GetBool("isJump"))
        {
            rigid2D.linearVelocity = Vector2.zero;
            rigid2D.AddForce(new Vector2(0, jumpUp), ForceMode2D.Impulse);
            animator.SetBool("isJump", true);
            //isJump = true;
        }
    }

    private void CheckGround()
    {
        Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0, 1, 0));

        RaycastHit2D rayHit = Physics2D.Raycast(
            rigid2D.position, Vector3.down, 1, LayerMask.GetMask("Ground"));

        if (rigid2D.linearVelocityY < 0 && rayHit.collider != null && rayHit.distance < 0.7f)
        {
            animator.SetBool("isJump", false);
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetTrigger("Attack");
            //ShowSlash();
        }
    }

    private void AttackSlash()
    {
        Instantiate(slash, transform.position, Quaternion.identity);
    }

}
