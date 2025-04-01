using UnityEngine;

public class Enemy3 : EnemyBase
{
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 30;
        Speed = 2f;
        Damage = 3;
    }
    public override void Attack()
    {
        Debug.Log("Enemy3이 공격합니다!");
    }
}
