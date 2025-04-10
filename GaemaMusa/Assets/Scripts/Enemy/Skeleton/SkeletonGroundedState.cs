using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected Skeleton enemy;
    protected Transform player;

    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy)
        : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Eneter()
    {
        base.Eneter();

        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) < 2)
        {
            stateMachine.ChangeState(enemy.battleState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
