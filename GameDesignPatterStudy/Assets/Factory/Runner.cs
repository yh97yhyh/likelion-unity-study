using UnityEngine;

public class Runner : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 30f;
        Speed = 6f;
        Damage = 5f;
    }

    public override void Attack()
    {
        Debug.Log("Runner가 빠르게 연속 공격을 합니다!");
    }
}
