using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject ExplosionEffect;
    Transform pos;
    int Attack = 10;

    void Start()
    {
        pos = GameObject.FindWithTag("Player").GetComponent<Player>().LauncherPos;
    }

    void Update()
    {
        transform.position = pos.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HandleTrigger(collision);
    }

    private void OnTriggerStay2D(Collider2D collision) // 충돌 지속
    {
        HandleTrigger(collision);
    }

    private void HandleTrigger(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            collision.gameObject.GetComponent<Monster>().Damage(Attack++);
            ShowEffect(collision.transform.position);
        }

        if (collision.CompareTag("Boss"))
        {
            ShowEffect(collision.transform.position);
        }
    }

    private void ShowEffect(Vector3 position)
    {
        GameObject effect = Instantiate(ExplosionEffect, position, Quaternion.identity);
        Destroy(effect, 1);
    }

}
