using UnityEngine;

public class FunctionExample : MonoBehaviour
{
    void Start()
    {
        SayHello();
        int total = AddNums(3, 5);
        print("total : " + total);
    }

    void Update()
    {
        
    }

    void SayHello()
    {
        print("Hello Unity!");
    }

    int AddNums(int a, int b)
    {
        return a + b;
    }
}
