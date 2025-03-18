using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float moveSpeed = 5f;
    public Animator MyAnimator;

    // 총알
    public Transform LauncherPos = null;
    public GameObject[] MyBullets;
    public GameObject MyLaser;
    public float gValue = 0;

    //[SerializeField] // pirvat 인스펙터 사용하는 법
    //private GameObject powerUp;

    public GameObject PowerUpEffect;
    private int _power;
    public int Power
    {
        get { return _power; }
        set
        {
            if (_power != value)
            {
                _power = value;
            }
        }
    }

    // 레이저
    private Vector2 minBounds;
    private Vector2 maxBounds;

    public Image Gage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Power = 0;
    }

    void Start()
    {
        Power = 0;
        MyAnimator = GetComponent<Animator>();
        SetCameraBound();
    }

    private void SetCameraBound()
    {
        // 화면 경계 설정
        Camera cam = Camera.main;
        Vector3 bottomLeft = cam.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 topRight = cam.ViewportToWorldPoint(new Vector3(1, 1, 0));

        minBounds = new Vector2(bottomLeft.x, bottomLeft.y);
        maxBounds = new Vector2(topRight.x, topRight.y);
    }

    void Update()
    {
        MovePlayer();
        SetAnimation();
        FireBullet();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0);

        // 경계를 벗어나지 않도록 위치 제한
        newPosition.x = Mathf.Clamp(newPosition.x, minBounds.x, maxBounds.x);
        newPosition.y = Mathf.Clamp(newPosition.y, minBounds.y, maxBounds.y);

        transform.position = newPosition;
    }

    private void FireBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShowBullet();
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            ShowLaser();
            Gage.fillAmount = gValue;
        }
        else
        {
            gValue -= Time.deltaTime;
            gValue = (gValue <= 0) ? 0 : gValue;
            Gage.fillAmount = gValue;
        }
    }

    private void ShowBullet()
    {
        var i = Mathf.Min(Power, 3);
        Instantiate(MyBullets[i], LauncherPos.position, Quaternion.identity);
        //MyInstantiate(MyBullets[i], LauncherPos.position);
    }

    private void ShowLaser()
    {
        gValue += Time.deltaTime;
        if (gValue >= 1)
        {
            GameObject lazer = Instantiate(MyLaser, LauncherPos.position, Quaternion.identity);
            Destroy(lazer, 1);
            gValue = 0;
        }
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

    public void PowerUp()
    {
        if (Power < 3)
        {
            Power++;
        }
        ShowPowerUpEffect();
    }

    private void ShowPowerUpEffect()
    {
        GameObject effect = Instantiate(PowerUpEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }

    private void MyInstantiate(GameObject go, Vector2 pos)
    {
        GameObject bullet = PoolManager.Instance.Get(go);
        bullet.transform.position = pos;
    }
}

    