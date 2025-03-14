using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int flat = 1;
    private int speed = 2;

    public GameObject MyBullet;
    public Transform pos1;
    public Transform pos2;

    public GameObject ExplosionEffect;


    void Start()
    {
        StartCoroutine(FireMissile());
    }

    IEnumerator FireMissile()
    {
        while (true)
        {
            Instantiate(MyBullet, pos1.position, Quaternion.identity);
            Instantiate(MyBullet, pos2.position, Quaternion.identity);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void Damage()
    {
        ShowEffect();
        //Destroy(gameObject);
    }

    private void ShowEffect()
    {
        GameObject effect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
