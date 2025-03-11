using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton Instance { get; set; }

    // Start()보다 더 빠르게 실행됨 (한 번 실행)
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 씬이 바뀌어도 유지되게 함
        }
        else
        {
            Destroy(gameObject); // 중복 생성 방지
        }
    }

    public void PrintMessage()
    {
        //print("싱글톤 메시지 출력!");
    }
}
