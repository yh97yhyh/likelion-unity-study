using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            enemy.SetMovementStrategy(new StraightMovement());
            Debug.Log("직선 이동");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            enemy.SetMovementStrategy(new ZigzagMovement());
            Debug.Log("지그재그 이동");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            enemy.SetMovementStrategy(new CircularMovement());
            Debug.Log("원형 이동");
        }
    }
}
