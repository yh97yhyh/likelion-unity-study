using UnityEngine;

public class SwordSkillController : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private Player player;

    private bool canRotate;
    private bool isReturning;

    [SerializeField] private float returnSpeed = 12;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
    }

    public void SetupSword(Vector2 _dir, float _gravityScale, Player _player)
    {
        rb.linearVelocity = _dir;
        rb.gravityScale = _gravityScale;
        player = _player;

        anim.SetBool("Rotation", true);
    }

    private void Update()
    {
        if (canRotate)
        {
            transform.right = rb.linearVelocity;
        }

        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, returnSpeed * Time.deltaTime);
            if (Vector2.Distance(transform.position, player.transform.position) < 1)
            {
                player.ClearSword();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) // 부딪히면 박히도록
    {
        if (collision.tag.Equals("Player"))
        {
            return;
        }

        anim.SetBool("Rotation", false);

        canRotate = false;
        cd.enabled = false;

        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;

        transform.parent = collision.transform;
    }

    public void ReturnSword()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        transform.parent = null;
        isReturning = true;
    }
}
