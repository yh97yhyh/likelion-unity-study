using UnityEngine;

public class Shape : MonoBehaviour
{
    public string shapeName;

    public Rigidbody2D rigidBody;
    public Vector2 velocity;

    public virtual void Start()
    {
        Debug.Log($"Hello, my shpe is {shapeName}");
        rigidBody.linearVelocity = velocity;
    }

    void Update()
    {
        
    }
}
