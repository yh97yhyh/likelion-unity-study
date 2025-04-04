using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMchine stateMachine;

    private string animationBoolName;

    public PlayerState(Player _player, PlayerStateMchine _stateMachine, string _animationBoolName)
    {
        player = _player;
        stateMachine = _stateMachine;
        animationBoolName = _animationBoolName;
    }

    public virtual void Enter()
    {
        Debug.Log($"Enter - {animationBoolName}");
    }

    public virtual void Update()
    {
        Debug.Log($"Update - {animationBoolName}");
    }

    public virtual void Exit()
    {
        Debug.Log($"Exit - {animationBoolName}");
    }
}
