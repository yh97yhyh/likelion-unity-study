using UnityEngine;

public class MBullet : MonoBehaviour
{
    public float moveSpeed = 4f;

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            // 플레이어 지우기
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
