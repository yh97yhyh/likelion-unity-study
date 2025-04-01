using UnityEngine;

public class Enemy5 : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 100;
        Speed = 1f;
        Damage = 10;
    }
    public override void Attack()
    {
        Debug.Log("Enemy5이 공격합니다!");
    }
}
