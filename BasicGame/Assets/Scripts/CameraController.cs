using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform sphere; // 따라갈 Sphere 오브젝트
    public float smoothSpeed = 5.0f; // 부드러운 이동 속도

    void LateUpdate()
    {
        if (sphere != null)
        {
            Vector3 targetPosition = new Vector3(sphere.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
