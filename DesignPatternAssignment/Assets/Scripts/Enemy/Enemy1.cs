using UnityEngine;

public class Enemy1 : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 10;
        Speed = 3f;
        Damage = 1;
    }
    public override void Attack()
    {
        Debug.Log("Enemy1이 공격합니다!");
    }
}
