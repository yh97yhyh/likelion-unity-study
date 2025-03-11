using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; set; }
    public GameObject Smallenemy;
    public GameObject NormalEnemy1;
    public GameObject NormalEnemy2;
    public GameObject BossEnemy;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 1.0f, 0.5f);
    }

    public void SetSpawnRate()
    {
        print("SetSpawnRate()");
        if (GameManager.Instance.CurStage == Stage.First)
        {
            InvokeRepeating("SpawnEnemy", 1.0f, 0.5f);
        }
        else if (GameManager.Instance.CurStage == Stage.Second)
        {
            InvokeRepeating("SpawnEnemy", 2.0f, 1.2f);
        }
        else
        {
            SpawnEnemy();
        }
    }

    public void StopRepeating()
    {
        CancelInvoke("SpawnEnemy");
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(-2f, 2f);
        int randomProb = Random.Range(1, 101);
        if (GameManager.Instance.CurStage == Stage.First)
        {
            Instantiate(Smallenemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);

        } else if (GameManager.Instance.CurStage == Stage.Second)
        {
            if (randomProb <= 50)
            {
                Instantiate(NormalEnemy1, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
            }
            else
            {
                Instantiate(NormalEnemy2, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
            }
        }
        else
        {
            Instantiate(BossEnemy, new Vector3(randomX, transform.position.y, 0f), Quaternion.identity);
        }
    }
}
