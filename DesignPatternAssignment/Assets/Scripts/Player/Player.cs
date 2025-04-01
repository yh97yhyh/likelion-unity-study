using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 50;
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
                gameObject.SetActive(false);
            }
        }
    }

    public float moveSpeed = 5f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveX = 0f;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }

        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
