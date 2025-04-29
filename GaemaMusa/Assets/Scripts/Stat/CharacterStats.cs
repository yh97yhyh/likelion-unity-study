using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    [Header("Attack Stat")]
    public Stat strength;
    public Stat agility;
    public Stat inteligence;
    public Stat vitality;

    [Header("Defence Stat")]
    public Stat maxHelath;
    public Stat armor;
    public Stat evasion;


    public Stat damage;

    [SerializeField]
    private int currentHealth;

    protected virtual void Start()
    {
        currentHealth = maxHelath.GetValue();
    }

    public virtual void DoDamage(CharacterStats _targetStats)
    {
        int totalEvasion = _targetStats.evasion.GetValue() + _targetStats.agility.GetValue();

        if (Random.Range(0, 100) < totalEvasion)
        {
            Debug.Log("회피했습니다.");
            return;
        }


        int totalDamage = damage.GetValue() + strength.GetValue();
        _targetStats.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if (currentHealth < 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
    }
}
