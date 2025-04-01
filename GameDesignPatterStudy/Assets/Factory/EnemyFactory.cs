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

    public GameObject GruntPrefab;
    public GameObject RunnerPrefab;
    public GameObject TankPrefab;

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
            case EnemyType.Grunt:
                enemyObject = Instantiate(GruntPrefab);
                break;
            case EnemyType.Runner:
                enemyObject = Instantiate(RunnerPrefab);
                break;
            case EnemyType.Tank:
                enemyObject = Instantiate(TankPrefab);
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
