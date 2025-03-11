using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Stage Level { get; set; }
    public float moveSpeed = 2.0f;
    public int hitNum = 0;

    void Start()
    {
        Level = GameManager.Instance.CurStage;
    }

    void Update()
    {
        float distanceY = 0f;
        if (GameManager.Instance.CurStage == Stage.First)
        {
            distanceY = moveSpeed * Time.deltaTime;
        }
        else if (GameManager.Instance.CurStage == Stage.Second)
        {
            distanceY = moveSpeed * 0.5f * Time.deltaTime;
        }
        else
        {
            distanceY = moveSpeed * 0.2f * Time.deltaTime;
        }
        transform.Translate(0, -distanceY, 0);
    }

    private void OnBecameInvisible() // 카메라에서 보이지 않으면 호출
    {
        Destroy(gameObject); // 오브젝트 삭제
    }

    public void AddHitNum()
    {
        hitNum += 1;
    }
}
