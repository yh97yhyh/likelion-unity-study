using Unity.VisualScripting;
using UnityEngine;

public enum SwordType
{
    Regular,
    Bounce,
    Pierce,
    Spin
}

public class SwordSkill : Skill
{
    public SwordType swordType = SwordType.Regular;

    [Header("Bounce Info")]
    [SerializeField] private float bounceSpeed;
    [SerializeField] private float bounceAmount;
    [SerializeField] private float bounceGravity;

    [Header("Pierce Info")]
    [SerializeField] private int pierceAmount;
    [SerializeField] private float pierceGravity;

    [Header("Spin Info")]
    [SerializeField] private float hitCooldown;
    [SerializeField] private float maxTravelDistance;
    [SerializeField] private float spinDuration;
    [SerializeField] private float spinGravity;

    [Header("Skill Info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchForce;
    [SerializeField] private float swordGravity;
    [SerializeField] private float freezeTimeDuration;
    [SerializeField] private float returnSpeed;

    private Vector2 finalDir;

    [Header("Aim Dots Info")]
    [SerializeField] private int numberofDots;
    [SerializeField] private float spaceBeetwenDots;
    [SerializeField] private GameObject dotPrefab;
    [SerializeField] private Transform dotsParent;

    private GameObject[] dots;

    protected override void Start()
    {
        base.Start();

        GenerateDots();

        SetupGravity();
    }

    private void SetupGravity()
    {
        if (swordType == SwordType.Bounce)
        {
            swordGravity = bounceGravity;
        }
        else if (swordType == SwordType.Pierce )
        {
            swordGravity = pierceGravity;
        }
        else if (swordType == SwordType.Spin)
        {
            swordGravity = spinGravity;
        }
    }


    protected override void Update()
    {
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            Vector2 aimDirection = AimDirection();
            finalDir = new Vector2(aimDirection.normalized.x * launchForce.x, aimDirection.normalized.y * launchForce.y);
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            for(int i=0; i<dots.Length; i++)
            {
                dots[i].transform.position = DotsPosition(i * spaceBeetwenDots);
            }
        }
    }

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
        SwordSkillController swordSkillController = newSword.GetComponent<SwordSkillController>();

        swordSkillController.SetupSword(finalDir, swordGravity, player, freezeTimeDuration, returnSpeed);

        if (swordType == SwordType.Bounce)
        {
            swordSkillController.SetupBounce(true, bounceAmount, bounceSpeed);
        }
        else if (swordType == SwordType.Pierce)
        {
            swordSkillController.SetupPierce(pierceAmount);
        }
        else if (swordType == SwordType.Spin)
        {
            swordSkillController.SetupSpin(true, maxTravelDistance, spinDuration, hitCooldown);
        }

        player.AssignNewSword(newSword);

        DotsActive(false);
    }

    public Vector2 AimDirection()
    {
        Vector2 playerPosition = player.transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - playerPosition;

        return direction;
    }

    public void DotsActive(bool _isActive)
    {
        for(int i=0; i<dots.Length; i++)
        {
            dots[i].SetActive(_isActive);
        }
    }

    private void GenerateDots()
    {
        dots = new GameObject[numberofDots];
        for(int i=0; i<numberofDots; i++)
        {
            dots[i] = Instantiate(dotPrefab, player.transform.position, Quaternion.identity, dotsParent);
            dots[i].SetActive(false);
        }
    }

    private Vector2 DotsPosition(float t)
    {
        Vector2 aimDirection = AimDirection();
        Vector2 position = (Vector2)player.transform.position 
            + new Vector2(aimDirection.normalized.x * launchForce.x, aimDirection.normalized.y * launchForce.y)
            * t + 0.5f * (Physics2D.gravity * swordGravity) * (t * t);

        return position;
    }
}
