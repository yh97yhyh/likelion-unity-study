using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
