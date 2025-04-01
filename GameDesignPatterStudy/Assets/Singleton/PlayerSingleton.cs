using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.Instance.AddScore(10);
        }
    }
}
