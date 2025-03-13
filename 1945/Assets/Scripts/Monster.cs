using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Monster : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float fireDelay = 1f;

    public Transform ms1;
    public Transform ms2;
    public GameObject MyBullet;

    public GameObject Item;

    public GameObject ExplosionEffect;

    void Start()
    {
        Invoke("CreateBullet", fireDelay);
    }

    void Update()
    {
        transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
        DropItem();
    }

    private void CreateBullet()
    {
        Instantiate(MyBullet, ms1.position, Quaternion.identity);
        Instantiate(MyBullet, ms2.position, Quaternion.identity);

        Invoke("CreateBullet", fireDelay);
    }

    private void DropItem()
    {
        int randomProb = Random.Range(1, 101);
        if (randomProb <= 30)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
