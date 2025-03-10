using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    public float scrollSpeed = 0.4f; // 스크롤할 속도
    private Material curMaterial;// Quad의 Material 데이터를 받아올 객체

    void Start()
    {
        curMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        Vector2 newOffset = curMaterial.mainTextureOffset; // 새롭게 지정해줄 offset 객체
        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime)); // y값에 속도 보정해서 더해줌
        curMaterial.mainTextureOffset = newOffset; // 새로운 offset
    }
}
