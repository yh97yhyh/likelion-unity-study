using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.02f;
    public Material MyMaterial { get; set; }

    void Start()
    {
        MyMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        float newOffsetY = MyMaterial.mainTextureOffset.y + scrollSpeed * Time.deltaTime;
        Vector2 newOffset = new Vector2(0, newOffsetY);
        MyMaterial.mainTextureOffset = newOffset;
    }
}
