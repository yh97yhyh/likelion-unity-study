using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private int directionFlag = 1;
    private int moveSpeed = 2;
    private int hp = 20;

    public GameObject MyBullet;
    public GameObject CircleBullet;
    public Transform pos1;
    public Transform pos2;

    public GameObject ExplosionEffect;


    void Start()
    {
        StartCoroutine(FireCircle());
        StartCoroutine(FireMissile());
    }

    private void Update()
    {
        if (transform.position.x >= 1)
        {
            directionFlag *= -1;
        }
        if (transform.position.x <= -1)
        {
            directionFlag *= -1;
        }

        transform.Translate(directionFlag * moveSpeed * Time.deltaTime, 0, 0);
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

    IEnumerator FireCircle()
    {
        //공격주기
        float attackRate = 3;
        //발사체 생성갯수
        int count = 30;
        //발사체 사이의 각도
        float intervalAngle = 360 / count;
        //가중되는 각도(항상 같은 위치로 발사하지 않도록 설정
        float weightAngle = 0f;

        //원 형태로 방사하는 발사체 생성(count 갯수 만큼)
        while (true)
        {

            for (int i = 0; i < count; ++i)
            {
                //발사체 생성
                GameObject clone = Instantiate(CircleBullet, transform.position, Quaternion.identity);

                //발사체 이동 방향(각도)
                float angle = weightAngle + intervalAngle * i;
                //발사체 이동 방향(벡터)
                //Cos(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float x = Mathf.Cos(angle * Mathf.Deg2Rad);
                //sin(각도)라디안 단위의 각도 표현을 위해 pi/180을 곱함
                float y = Mathf.Sin(angle * Mathf.Deg2Rad);

                //발사체 이동 방향 설정
                clone.GetComponent<BBullet>().Move(new Vector2(x, y));
            }
            //발사체가 생성되는 시작 각도 설정을 위한변수
            weightAngle += 1;

            //3초마다 미사일 발사
            yield return new WaitForSeconds(attackRate);

        }
    }

    public void Damage()
    {
        ReduceHp();
        ShowEffect();
        //Destroy(gameObject);
    }

    private void ReduceHp()
    {
        if (hp > 0)
        {
            hp--;

            if (hp == 0)
            {
                Destroy(gameObject);
            }
        }
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
