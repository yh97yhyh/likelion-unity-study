using UnityEngine;

public class PlayerHangingState : PlayerState
{
    public PlayerHangingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) 
        : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(rb.linearVelocityX, Mathf.Max(rb.linearVelocityY, -player.slideSpeed));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            float jumpDirection = player.facingDir * -1;
            rb.linearVelocity = new Vector2(jumpDirection * player.moveSpeed, player.jumpForce);
            player.Flip();
            stateMachine.ChangeState(player.jumpState);
        }

        if (!player.IsWallDetected() && !player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.airState);
        }

        if (player.IsGroundDetected())
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
