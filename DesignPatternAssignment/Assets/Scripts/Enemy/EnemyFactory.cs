using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    private static EnemyFactory _instance;
    public static EnemyFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<EnemyFactory>();

                if (_instance == null)
                {
                    GameObject gameObject = new GameObject("EnemyFactory");
                    _instance = gameObject.AddComponent<EnemyFactory>();
                }
            }

            return _instance;
        }
    }

    public GameObject Enemy1Prefab;
    public GameObject Enemy2Prefab;
    public GameObject Enemy3Prefab;
    public GameObject Enemy4Prefab;
    public GameObject Enemy5Prefab;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public IEnemy CreateEnemy(EnemyType type, Vector3 position)
    {
        GameObject enemyObject = null;

        switch (type)
        {
            case EnemyType.Enemy1:
                enemyObject = Instantiate(Enemy1Prefab);
                break;
            case EnemyType.Enemy2:
                enemyObject = Instantiate(Enemy2Prefab);
                break;
            case EnemyType.Enemy3:
                enemyObject = Instantiate(Enemy3Prefab);
                break;
            case EnemyType.Enemy4:
                enemyObject = Instantiate(Enemy4Prefab);
                break;
            case EnemyType.Enemy5:
                enemyObject = Instantiate(Enemy5Prefab);
                break;
            default:
                Debug.LogError($"Unknown enemy type : {type}");
                return null;

        }

        IEnemy enemy = enemyObject.GetComponent<IEnemy>();
        enemy.Initialize(position);
        return enemy;
    }
}
