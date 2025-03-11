using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5.0f;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        moveControl();
    }

    void moveControl()
    {
        float distanceX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        transform.Translate(distanceX, 0, 0);
    }
}
