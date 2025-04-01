using UnityEngine;

public enum EnemyType
{
    Enemy1,
    Enemy2,
    Enemy3,
    Enemy4,
    Enemy5
}

public interface IEnemy
{
    void Initialize(Vector3 position);
    void Attack();
    void TakeDamage(int damage);
}

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    public int Health;
    public float Speed;
    public int Damage;

    public virtual void Initialize(Vector3 position)
    {
        transform.position = position;
    }

    public abstract void Attack();

    public virtual void TakeDamage(int damage)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player player = collision.GetComponent<Player>();
            if (player != null)
            {
                player.TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
}
