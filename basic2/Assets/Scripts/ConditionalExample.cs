using UnityEngine;

public class ConditionalExample : MonoBehaviour
{
    public int health = 100;
    void Start()
    {

    }
    void Update()
    {

        if (health <= 0)
        {
            print("Game Over");
        }
        else
        {
            health -= 1;
            print("Health : " + health);
        }
    }
}
