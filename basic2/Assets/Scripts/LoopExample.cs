using UnityEngine;

public class LoopExample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //for(int i=1; i<=10; i++)
        //{
        //    print("Count : " + i);
        //}

        var count = 0;
        while (count < 5)
        {
            print("While Count" + count);
            count++;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
