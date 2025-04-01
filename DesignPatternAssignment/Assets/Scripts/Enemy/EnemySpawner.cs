using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField]
    private float spawnInterval = 5f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            SpawnRandomEnemy();
            timer = 0;
        }
    }

    private void SpawnRandomEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
        EnemyType randomgType = (EnemyType)Random.Range(0, 5);
        IEnemy enemy = EnemyFactory.Instance.CreateEnemy(randomgType, spawnPosition);
        Debug.Log($"{randomgType} is created. {spawnPosition}");
    }
}
