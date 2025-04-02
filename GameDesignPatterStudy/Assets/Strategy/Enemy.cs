using UnityEngine;

public interface ImovementStrategy
{
    void Move(Transform transform, float speed);
}

public class StraightMovement: ImovementStrategy
{
    public void Move(Transform transform, float speed)
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

public class ZigzagMovement : ImovementStrategy
{
    private float amplitude = 2f;
    private float frequency = 2f;
    private float time = 0;

    public void Move(Transform transform, float speed)
    {
        time += Time.deltaTime;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float xOffset = Mathf.Sin(time * frequency) * amplitude;
        transform.position = new Vector3(xOffset, transform.position.y, transform.position.z);
    }
}

public class CircularMovement : ImovementStrategy
{
    private float radius = 5f;
    private float angularSpeed = 50f;
    private float angle = 0;
    private Vector3 center;
    private bool isInitialize = false;

    public void Move(Transform transform, float speed)
    {
        if (!isInitialize)
        {
            center = transform.position;
            isInitialize = true;
        }

        angle += angularSpeed * Time.deltaTime;

        float x = center.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
        float z = center.z + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;

        transform.position = new Vector3(x, transform.position.y, z);

        // 회전방향 고려
        transform.LookAt(
            new Vector3(center.x + Mathf.Cos((angle + 90) * Mathf.Deg2Rad) * radius, 
            transform.position.y,
            center.x + Mathf.Sin((angle + 90) * Mathf.Deg2Rad) * radius));
    }
}

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3f;

    private ImovementStrategy movementStrategy;

    void Start()
    {
        movementStrategy = new StraightMovement();
    }

    void Update()
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(transform, moveSpeed);
        }
    }

    public void SetMovementStrategy(ImovementStrategy strategy)
    {
        movementStrategy = strategy;
    }
}
