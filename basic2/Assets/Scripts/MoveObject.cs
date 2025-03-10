using UnityEngine;
using UnityEngine.InputSystem;

public class MoveObject : MonoBehaviour
{
    public float speed = 5.0f;

    void Start()
    {
        
    }

    void Update()
    {
        //float move = Input.GetAxis("Horizontal");
        //transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        var move2D = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        var move3D = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //transform.position += move3D * speed * Time.deltaTime;
        transform.Translate(move3D * speed * Time.deltaTime);
    }
}
