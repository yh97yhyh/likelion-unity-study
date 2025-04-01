using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 100;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            EventManager.Instance.TriggerEvent("PlayerHealthChanged", _health);

            if (_health <= 0)
            {
                EventManager.Instance.TriggerEvent("PlayerDied");
            }
        }
    }

    private void TakeDamage(int damage)
    {
        Health -= damage;
    }

    void Update()
    {
        //테스트용: 스페이스 키를 누르면 데미지 받기
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Health > 0)
            {
                TakeDamage(10);
            }
        }
    }
}
