using UnityEngine;

public class Shadow : MonoBehaviour
{
    private GameObject player;
    public float speed = 10;

    void Start()
    {
        
    }

    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Vector3.Lerp(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
