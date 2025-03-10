using UnityEngine;

public class Player
{
    public string Name { get; set; }
    public int Score { get; set; }

    public Player()
    {
        Name = "default";
        Score = 0;
    }

    public Player(string name, int score)
    {
        Name = name;
        Score = score;
    }

    public void ShowInfo()
    {
        Debug.Log("Name : " + Name);
        Debug.Log("Score : " + Score);
    }
}

public class ClassExample : MonoBehaviour
{
    void Start()
    {
        var player = new Player("ภüป็", 100);
        player.ShowInfo();
    }

    void Update()
    {
        
    }
}
