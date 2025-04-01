using UnityEngine;

public enum EnemyType
{
    Grunt,
    Runner,
    Tank,
    Boss
}

public interface IEnemy
{
    void Initialize(Vector3 position);
    void Attack();
    void TakeDamage(float damage);
}

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public float Health;
    public float Speed;
    public float Damage;

    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public abstract void Attack();

    public virtual void TakeDamage(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }
}
