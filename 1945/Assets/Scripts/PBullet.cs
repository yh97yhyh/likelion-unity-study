using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float moveSpeed = 3.0f;

    // °ø°Ý·Â

    void Start()
    {
        
    }

    void Update()
    {
        //transform.Translate(0, moveSpeed * Time.deltaTime, 0);
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Destroy(collision.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
