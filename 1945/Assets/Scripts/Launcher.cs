using System.Collections;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float shootInterval = 0.4f;
    public GameObject MyBUllet;

    void Start()
    {
        StartCoroutine(ShootCoroutine());
    }

    IEnumerator ShootCoroutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void Shoot()
    {
        Instantiate(MyBUllet, transform.position, Quaternion.identity);
    }
}
