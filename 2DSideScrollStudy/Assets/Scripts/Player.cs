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

            for(int i=0; i<shadows.Count; i++)
            {
                shadows[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }
        }
        else if (direction.x > 0)
        {
            sp.flipX = false;
            animator.SetBool("isRun", true);

            for (int i = 0; i < shadows.Count; i++)
            {
                shadows[i].GetComponent<SpriteRenderer>().flipX = sp.flipX;
            }
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

}
