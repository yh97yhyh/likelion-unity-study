using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public float jumpUp = 1;
    public Vector3 direction;

    Animator animator;
    Rigidbody2D rigid2D;
    SpriteRenderer sp;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        direction = Vector2.zero;
    }

    void Update()
    {
        HandleKeyInput();
        Move();
    }

    private void HandleKeyInput()
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
}
