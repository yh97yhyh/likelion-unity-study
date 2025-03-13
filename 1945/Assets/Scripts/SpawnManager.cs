using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float spawnStartX = -2;
    public float spawnEndX = 2;
    public float spawnStartTime = 1;
    public float spawnStopTime = 10;
    public GameObject MyMonster;
    public GameObject MyMonster2;

    private bool isMonster1 = true;
    private bool isMonster2 = true;


    void Start()
    {
        StartCoroutine("RandomSpawn");
        Invoke("Stop", spawnStopTime);
    }

    IEnumerator RandomSpawn()
    {
        while (isMonster1)
        {
            yield return new WaitForSeconds(spawnStartTime);
            float x = Random.Range(spawnStartX, spawnEndX);
            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(MyMonster, pos, Quaternion.identity);
        }
    }

    IEnumerator RandomSpawn2()
    {
        while (isMonster2)
        {
            yield return new WaitForSeconds(spawnStartTime + 2);
            float x = Random.Range(spawnStartX, spawnEndX);
            Vector2 pos = new Vector2(x, transform.position.y);
            Instantiate(MyMonster2, pos, Quaternion.identity);
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

        // º¸½º
    }
}
