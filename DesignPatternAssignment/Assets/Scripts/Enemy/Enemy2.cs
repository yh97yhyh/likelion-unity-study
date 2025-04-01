using UnityEngine;

public class Enemy2 : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 20;
        Speed = 3f;
        Damage = 2;
    }
    public override void Attack()
    {
        Debug.Log("Enemy2이 공격합니다!");
    }
}
