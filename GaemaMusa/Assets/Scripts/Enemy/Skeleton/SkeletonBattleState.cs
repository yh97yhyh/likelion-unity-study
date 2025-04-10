using UnityEngine;

public class SkeletonBattleState : EnemyState
{
    Skeleton enemy;
    private int moveDir;

    private Transform player;

    public SkeletonBattleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Skeleton _enemy)
        : base(_enemyBase, _stateMachine, _animBoolName)
    {
        enemy = _enemy;
    }

    public override void Eneter()
    {
        base.Eneter();

        player = player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void Update()
    {
        base.Update();

        if (enemy.IsPlayerDetected())
        {
            stateTimer -= enemy.battleTime;

            if (enemy.IsPlayerDetected().distance < enemy.attackDistance)
            {
                if (CanAttack())
                {
                    stateMachine.ChangeState(enemy.attackState);
                }
            }
        }
        else
        {
            if (stateTimer < 0 || Vector2.Distance(player.transform.position, enemy.transform.position) > 7)
            {
                stateMachine.ChangeState(enemy.idleState);
            }
        }

        moveDir = player.position.x > enemy.transform.position.x ? 1 : -1;
        enemy.SetVelocity(enemy.moveSpeed * moveDir, rb.linearVelocityY);
    }

    public override void Exit()
    {
        base.Exit();
    }

    private bool CanAttack()
    {
        if (Time.time >= enemy.lastTimeAttacked + enemy.attackColldown)
        {
            enemy.lastTimeAttacked = Time.time;
            return true;
        }

        return false;
    }
}
