using UnityEngine;

public class VectorStudy : MonoBehaviour
{
    //public Vector2 v2 = new Vector2(10, 10);
    //public Vector3 v3 = new Vector3(10, 10, 5);
    //public Vector4 v4 = new Vector4(1.0f, 0.5f, 0.0f, 1.0f); // 좌표보다 색상에 많이 씀 (RGBA)

    void Start()
    {
        //var vector1 = new Vector3(1, 2, 3);
        //var vector2 = new Vector3(4, 5, 6);
        //var result = vector1 + vector2;
        //print("Vector : " + result);
        //print("Vector의 길이 : " + result.magnitude);

        // 정규화 normalize
        // 벡터의 크기를 1로 만들고 방향만 유지
        var vectorA = new Vector3(3, 0, 0);
        var normalizedVector = vectorA.normalized;
        print("1의길이 방향만 설정하는 정규화 : " + normalizedVector);
    }

    void Update()
    {
        
    }
}
