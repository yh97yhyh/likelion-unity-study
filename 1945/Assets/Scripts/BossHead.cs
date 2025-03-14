using UnityEngine;

public class BossHead : MonoBehaviour
{

    public GameObject BossBullet;

    // 애니메이션에서 함수 사용
    public void FireRIghtDown()
    {
        GameObject go = Instantiate(BossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BBullet>().Move(new Vector2(1, -1));
    }

    public void FireLeftDown()
    {
        GameObject go = Instantiate(BossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BBullet>().Move(new Vector2(-1, -1));
    }

    public void FireDown()
    {
        GameObject go = Instantiate(BossBullet, transform.position, Quaternion.identity);
        go.GetComponent<BBullet>().Move(new Vector2(-0, -1));
    }
}
