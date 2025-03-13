using UnityEngine;

public class HBullet : MonoBehaviour
{
    public GameObject Target; // 플레이어
    public float moveSpeed = 3f;
    Vector2 homingVector;
    Vector2 normalizedHomingVector;

    void Start()
    {
        SetHomingVector();
    }

    void Update()
    {
        transform.Translate(normalizedHomingVector * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
            // 플레이어 지우기
        }
    }

    private void SetHomingVector()
    {
        Target = GameObject.FindGameObjectWithTag("Player");
        homingVector = Target.transform.position - transform.position; // A - B : A를 바라보는 벡터 (Player - HBullet)
        normalizedHomingVector = homingVector.normalized; // Normalize

        //transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, moveSpeed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
