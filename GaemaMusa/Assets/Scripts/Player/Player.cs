using System.Collections;
using UnityEngine;

public class Player : Entity
{
    [Header("Attack Detail")]
    public Vector2[] attackMovement;
    public float counterAttackDuration = 0.2f;

    public bool isBusy { get; private set; }

    [Header("Move Info")]
    public float moveSpeed = 12f;
    public float jumpForce;

    [Header("Dash Info")]
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }

    public SkillManager skillManager { get; private set; }

    #region States

    public PlayerStateMachine stateMachine { get; private set; } // 플레이어의 상태를 관리하는 상태 머신

    // 플레이어의 상태 (대기 상태, 이동 상태)
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerWallSlideState wallSlideState { get; private set; }
    public PlayerWallJumpState wallJumpState { get; private set; }
    public PlayerPrimaryAttackState primaryAttackState { get; private set; }
    public PlayerCounterAttackState counterAttackState { get; private set; }
    public PlayerAimSwordState aimSwordState { get; private set; }
    public PlayerCatchSwordState catchSwordState { get; private set; }
    //public PlayerHangingState hangingState { get; private set; }

    #endregion


    protected override void Awake()
    {
        base.Awake();

        // 상태 머신 인스턴스 생성
        stateMachine = new PlayerStateMachine();

        // 각 상태 인스턴스 생성 (this: 플레이어 객체, stateMachine: 상태 머신, "Idle"/"Move": 상태 이름)
        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        wallSlideState = new PlayerWallSlideState(this, stateMachine, "WallSlide");
        wallJumpState = new PlayerWallJumpState(this, stateMachine, "Jump");
        primaryAttackState = new PlayerPrimaryAttackState(this, stateMachine, "Attack");
        counterAttackState = new PlayerCounterAttackState(this, stateMachine, "CounterAttack");
        aimSwordState = new PlayerAimSwordState(this, stateMachine, "AimSword");
        catchSwordState = new PlayerCatchSwordState(this, stateMachine, "CatchSword");
        //hangingState = new PlayerHangingState(this, stateMachine, "Hanging");
    }

    protected override void Start()
    {
        base.Start();

        skillManager = SkillManager.Instance;
        stateMachine.Initialize(idleState); // 게임 시작 시 초기 상태를 대기 상태(idleState)로 설정
    }

    protected override void Update()
    {
        base.Update();

        stateMachine.currentState.Update();
        CheckForDashInput();
    }

    private void CheckForDashInput()
    {
        //dashUsageTimer -= Time.deltaTime;

        //if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        //{
        //    dashUsageTimer = dashCooldown;
        //    dashDir = Input.GetAxisRaw("Horizontal");
        //    dashDir = dashDir == 0 ? facingDir : dashDir;
        //    stateMachine.ChangeState(dashState);
        //}

        //dashUsageTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift) && SkillManager.Instance.dash.CanUseSkill())
        {
            dashDir = Input.GetAxisRaw("Horizontal");
            dashDir = dashDir == 0 ? facingDir : dashDir;
            stateMachine.ChangeState(dashState);
        }
    }

    public IEnumerator BusyFor(float _seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }

    public void AnimationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }
}
