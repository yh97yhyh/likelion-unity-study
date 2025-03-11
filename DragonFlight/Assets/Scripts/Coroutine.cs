using System.Collections;
using UnityEngine;

public class Coroutine : MonoBehaviour
{
    // 시간이 걸리는 작업을 처리하기 위한 함수
    void Start()
    {
        //StartCoroutine("ExampleCoroutine");    
    }
    
    IEnumerator ExampleCoroutine()
    {
        Debug.Log("코루틴 시작");
        yield return new WaitForSeconds(2f); // 2초 대기
        Debug.Log("2초 후 다시 실행");
    }
}
