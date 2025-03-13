using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float moveSpeed = 3.0f;

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
        //Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
