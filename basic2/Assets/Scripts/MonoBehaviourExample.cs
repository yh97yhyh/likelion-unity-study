using UnityEngine;

public class MonoBehaviourExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print("Start : 게임이 시작될 때 호출됩니다");
    }

    // Update is called once per frame
    void Update()
    {
        print("Update : 프레임마다 호출됩니다");
    }

    private void FixedUpdate()
    {
        print("FixedUpdate : 물리 연산에 사용됩니다");        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }


}
