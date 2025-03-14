using UnityEngine;

public class BBullet : MonoBehaviour
{
    public float moveSpeed = 3f;
    Vector2 vec2 = Vector2.down;

    void Update()
    {
        transform.Translate(vec2 * moveSpeed * Time.deltaTime);
    }

    public void Move(Vector2 vec)
    {
        vec2 = vec;
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
