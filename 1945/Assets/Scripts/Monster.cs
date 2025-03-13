using UnityEngine;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float fireDelay = 1f;
    public Transform ms1;
    public Transform ms2;
    public GameObject MyBullet;

    void Start()
    {
        Invoke("CreateBullet", fireDelay);
    }

    private void CreateBullet()
    {
        Instantiate(MyBullet, ms1.position, Quaternion.identity);
        Instantiate(MyBullet, ms2.position, Quaternion.identity);

        Invoke("CreateBullet", fireDelay);
    }

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
