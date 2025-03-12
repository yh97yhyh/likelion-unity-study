using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    public Animator MyAnimator { get; set; }

    void Start()
    {
        MyAnimator = GetComponent<Animator>();

        // 화면 경계 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        SetAnimation();

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // 경계를 벗어나지 않도록 위치 제한
        //newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        //newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }

    private void SetAnimation()
    {
        if (Input.GetAxis("Horizontal") <= -0.25f)
        {
            MyAnimator.SetBool("left", true);
        }
        else
        {
            MyAnimator.SetBool("left", false);
        }

        if (Input.GetAxis("Horizontal") >= 0.25f)
        {
            MyAnimator.SetBool("right", true);
        }
        else
        {
            MyAnimator.SetBool("right", false);
        }

        if (Input.GetAxis("Vertical") >= 0.25f)
        {
            MyAnimator.SetBool("up", true);
        }
        else
        {
            MyAnimator.SetBool("up", false);
        }
    }
}