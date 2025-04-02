using UnityEngine;

public interface IEnemyState
{
    void EnterState(EnemyStateController enemy);
    void UpdateState(EnemyStateController enemy);
    void ExitState(EnemyStateController enemy);
    void OnTriggerState(EnemyStateController enemy, Collider other);
}

// 순찰 상태
public class PatrolState : IEnemyState
{
    private float patrolTimer = 0f;
    private int currentWaypointIndex = 0;

    public void EnterState(EnemyStateController enemy)
    {
        Debug.Log("순찰 상태 시작");

        // 첫 번재 웨이포인트로 이동
        
    }

    public void UpdateState(EnemyStateController enemy)
    {
        
    }

    public void ExitState(EnemyStateController enemy)
    {

    }

    public void OnTriggerState(EnemyStateController enemy, Collider other)
    {
    }
}

public class EnemyStateController : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
