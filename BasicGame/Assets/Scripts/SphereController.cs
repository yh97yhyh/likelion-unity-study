using UnityEngine;
using UnityEngine.SceneManagement;

public class SphereController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Vector3 startPosition; 
    public Transform mainCamera;
    private Vector3 cameraStartPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        startPosition = transform.position;

        if (mainCamera != null)
        {
            cameraStartPosition = mainCamera.position;
        }
    }

    void Update()
    {
        transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        print($"Sphere À§Ä¡ : {transform.position}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barriar"))
        {
            RestartGame();
        }
    }

    private void RestartGame()
    {
        transform.position = startPosition;
        rb.angularVelocity = Vector3.zero;

        if (mainCamera != null)
        {
            mainCamera.position = cameraStartPosition;
        }
    }

}
