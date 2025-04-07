using UnityEngine;

public abstract class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;

    protected float startTime;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
    }

    public virtual void LogicUpdate() { }

    public virtual void PhysicsUpdate() { }

    public virtual void Exit() { }
}
