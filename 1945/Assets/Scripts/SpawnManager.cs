using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SpawnManager : MonoBehaviour
{
    public float spawnStartX = -2;
    public float spawnEndX = 2;
    public float spawnStartTime = 1;
    public float spawnStopTime = 10;
    public GameObject MyMonster;
    public GameObject MyMonster2;
    public GameObject Boss;

    private bool isMonster1 = true;
    private bool isMonster2 = true;
    private bool isBoss = true;

    [SerializeField]
    GameObject BossWarningText;

    private void Awake()
    {
        BossWarningText.SetActive(false);
        //CreatePool();
    }

    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", spawnStopTime);
    }

    private void CreatePool()
    {
        PoolManager.Instance.CreatePool(MyMonster, 10);
        PoolManager.Instance.CreatePool(MyMonster2, 10);
    }

    IEnumerator RandomSpawn()
    {
        while (isMonster1)
        {
            yield return new WaitForSeconds(spawnStartTime + 1f);
            float x = Random.Range(spawnStartX, spawnEndX);
            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(MyMonster, pos, Quaternion.identity);
            //MyInstantiate(MyMonster, pos);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (isMonster2)
        {
            yield return new WaitForSeconds(spawnStartTime + 1f);
            float x = Random.Range(spawnStartX, spawnEndX);
            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(MyMonster2, pos, Quaternion.identity);
            //MyInstantiate(MyMonster2, pos);
        }
    }

    private void Stop()
    {
        isMonster1 = false;
        StopCoroutine("RandomSpawn");

        isMonster2 = true;
        StartCoroutine("RandomSpawn2");
        Invoke("Stop2", spawnStopTime + 20);
    }

    private void Stop2()
    {
        isMonster2 = false;
        StopCoroutine("RandomSpawn2");

        ShowBoss();
    }

    private void ShowBoss()
    {
        BossWarningText.SetActive(true);
        Invoke("HideBissWarning", 2f);
        Vector3 pos = new Vector3(0, 2.97f, 0);
        GameObject boss = Instantiate(Boss, pos, Quaternion.identity);
    }

    private void HideBissWarning()
    {
        BossWarningText.SetActive(false);
    }

    private void MyInstantiate(GameObject go, Vector2 pos)
    {
        GameObject monster = PoolManager.Instance.Get(go);
        monster.transform.position = pos;
    }
}
