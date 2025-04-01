using UnityEngine;

public class Enemy4 : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 50;
        Speed = 1f;
        Damage = 5;
    }
    public override void Attack()
    {
        Debug.Log("Enemy4이 공격합니다!");
    }
}
