using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 1.8f;
    public GameObject SmallExplosion;
    public GameObject NormalEplosion;
    public GameObject BossExplosion;

    void Start()
    {
        Singleton.Instance.PrintMessage();
    }

    void Update()
    {
        transform.Translate(0, moveSpeed * Time.deltaTime, 0);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) // 충돌 트리거
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.AddHitNum();

            SoundManager.Instance.PlayDieSound();
            Instantiate(SmallExplosion, transform.position, Quaternion.identity);

            if (enemy.Level == Stage.First)
            {
                Destroy(collision.gameObject);
                GameManager.Instance.AddScore(10);
            }
            else if (enemy.Level == Stage.Second)
            {
                if (enemy.hitNum >= 2)
                {
                    Instantiate(NormalEplosion, transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                    GameManager.Instance.AddScore(20);
                }
            }
            else
            {
                if (enemy.hitNum >= 10)
                {
                    Instantiate(BossExplosion, transform.position, Quaternion.identity);
                    Destroy(collision.gameObject);
                    GameManager.Instance.AddScore(100);
                    GameManager.Instance.IsRunning = false;
                }
            }

            Destroy(gameObject);
        }
    }
}
