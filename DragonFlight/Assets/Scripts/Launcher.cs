using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject bullet; // bullet prefab

    void Start()
    {
        // InvokeRepeating(함수 이름, 초기 지연시간, 지연할 시간)
        InvokeRepeating("Shoot", 0.4f, 0.4f);
    }

    void Shoot()
    {
        // 미사일 프리팹, 런처 포지션, 방향값 안줌
        Instantiate(bullet, transform.position, Quaternion.identity);
        SoundManager.Instance.PlayBulletSound();
    }

    void Update()
    {
        
    }


 
}
