using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Monster : MonoBehaviour
{
    public int hp = 100;
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

    private void CreateBullet()
    {
        Instantiate(MyBullet, ms1.position, Quaternion.identity);
        Instantiate(MyBullet, ms2.position, Quaternion.identity);

        Invoke("CreateBullet", fireDelay);
    }

    public void Damage(int attack)
    {
        hp -= attack;
        ShowEffect();
        if (hp <= 0)
        {
            DropItem();
            Destroy(gameObject);
            //MyDestroy();
        }
    }

    private void ShowEffect()
    {
        GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }

    private void DropItem()
    {
        int randomProb = Random.Range(1, 101);
        if (randomProb <= 50 && Player.Instance.Power < 3)
        {
            Instantiate(Item, transform.position, Quaternion.identity);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        //MyDestroy();
    }

    private void MyDestroy()
    {
        PoolManager.Instance.Return(gameObject);
    }
}
