using UnityEngine;

public class VariableExample : MonoBehaviour
{
    public string playerName = "Hero";
    public int playerScore = 0;
    public float speed = 5.5f;
    public bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print($"Player Name : {playerName}");
        print($"Player Score : {playerScore}");
        print($"Speed : {speed}");
        print($"Is Game Over? : {isGameOver}");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
