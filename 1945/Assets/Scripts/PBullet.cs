using UnityEngine;

public class PBullet : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public int attack = 10;

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
            CameraShake.Instance.ShakeCamera();
            collision.gameObject.GetComponent<Monster>().Damage(attack);
            Destroy(gameObject);
        }

        if (collision.CompareTag("Boss"))
        {
            CameraShake.Instance.ShakeCamera();
            collision.gameObject.GetComponent<Boss>().Damage(attack);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void MyDestroy()
    {
        PoolManager.Instance.Return(gameObject);
    }
}
