using UnityEngine;

public class Grunt : EnemyBase
{  
    public override void Initialize(Vector3 position)
    {
        base.Initialize(position);
        Health = 50f;
        Speed = 3f;
        Damage = 10f;
    }

    public override void Attack()
    {
        Debug.Log("Grunt가 근접 공격을 합니다!");
    }
}
