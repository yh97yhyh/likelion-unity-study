using UnityEngine;

public class Item : MonoBehaviour
{
    public float ItemVelocity = 120f;
    Rigidbody2D rig;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.AddForce(new Vector3(ItemVelocity, ItemVelocity, 0f));
    }

    void Update()
    {
        
    }
}
