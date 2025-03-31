using UnityEngine;

public class PlayerDust : MonoBehaviour
{
    public float lifetime = 0.5f;

    private void Awake()
    {
        Destroy(gameObject, lifetime);
    }
}
