using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMchine _stateMachine, string _animationBoolName)
        : base(_player, _stateMachine, _animationBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.N))
        {
            player.stateMachine.ChangeState(player.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
