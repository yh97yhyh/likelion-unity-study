using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public class Player : MonoBehaviour
{
    [Header("Player Attriutes")]
    public float speed = 5;
    public float jumpUp = 1;
    public float power = 2;
    public Vector3 direction;
    public GameObject slash;

    public GameObject shadow;
    List<GameObject> shadows = new List<GameObject>();

    public GameObject hitLazer;

    Animator animator;
    Rigidbody2D rigid2D;
    SpriteRenderer sp;

    public bool isJump = false;

    public Transform wallCheck;
    public float wallCheckDistance;
    public LayerMask wallLayer;
    public bool isWall;
    public float slidingSpeed;
    public float wallJumpPower;
    public bool isWallJump;
    public float isRight = 1;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        direction = Vector2.zero;
    }

    void Update()
    {
        if (!isWallJump)
        {
            KeyInput();
            Move();
            Jump();
            Attack();
        }

        CheckWall();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void KeyInput()
    {
        direction.x = Input.GetAxisRaw("Horizontal");

        if (direction.x < 0)
        {
            sp.flipX = true;
            animator.SetBool("isRun", true);

            for(int i=0; i<shadows.Count; i++)
            {
                shadows[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }

            isRight = -1;
        }
        else if (direction.x > 0)
        {
            sp.flipX = false;
            animator.SetBool("isRun", true);

            for (int i = 0; i < shadows.Count; i++)
            {
                shadows[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }

            isRight = 1;
        }
        else
        {
            animator.SetBool("isRun", false);

            for (int i = 0; i < shadows.Count; i++)
            {
                Destroy(shadows[i]);
                shadows.RemoveAt(i);
            }
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

        if (isWall)
        {
            isWallJump = false;
            rigid2D.linearVelocity = new Vector2(rigid2D.linearVelocityX, rigid2D.linearVelocityY * slidingSpeed);

            if (Input.GetKeyDown(KeyCode.W))
            {
                isWallJump = true;

                Invoke("FreezeX", 0.3f);

                rigid2D.linearVelocity = new Vector2(-isRight * wallJumpPower, 0.9f * wallJumpPower);

                sp.flipX = !sp.flipX;
                isRight = -isRight;
            }
        }
    }

    private void FreezeX()
    {
        isWallJump = false;
        
    }

    private void CheckWall()
    {
        isWall = Physics2D.Raycast(wallCheck.position, Vector2.right * isRight, wallCheckDistance, wallLayer);
        animator.SetBool("isGrab", isWall);
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
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
            Instantiate(hitLazer, transform.position, Quaternion.identity);
        }
    }

    public void AttackSlash()
    {
        if (sp.flipX == false)
        {
            rigid2D.AddForce(Vector2.right * power, ForceMode2D.Impulse);
        }
        else
        {
            rigid2D.AddForce(Vector2.left * power, ForceMode2D.Impulse);
        }

        GameObject go = Instantiate(slash, transform.position, Quaternion.identity);
        //go.GetComponent<SpriteRenderer>().flipX = sp.flipX;
    }

    public void RunShadow()
    {
        if (shadows.Count < 6)
        {
            GameObject go = Instantiate(shadow, transform.position, Quaternion.identity);
            go.GetComponent<Shadow>().speed = 10 - shadows.Count;
            shadows.Add(go);
        }
    }

    public void ShowDust(GameObject dust)
    {
        Instantiate(dust, transform.position + new Vector3(-0.073f, -0.358f, 0), Quaternion.identity);
    }

    public void ShowJumpDust(GameObject dust)
    {
        Instantiate(dust, transform.position + new Vector3(0f, 0.07f, 0), Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(wallCheck.position, Vector2.right * isRight * wallCheckDistance);
    }
}
