using UnityEngine;

public class MoveWithGravity : MonoBehaviour
{
    public Rigidbody rigidBody;

    public float jumpForce = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Rigidbody : 물리효과를 추가해 중력을 적용한다
            // AddForce : 점프를 위해 오브젝트에 힘을 준다
            // ForceMode.Impulse : 순간적으로 힘을 가하는 옵션
            rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
