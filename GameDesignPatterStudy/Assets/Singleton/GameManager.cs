using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    { 
        get 
        { 
            if (_instance == null)
            {
                _instance = FindFirstObjectByType<GameManager>();

                if (_instance == null)
                {
                    GameObject gameObject = new GameObject("GameManager");
                    _instance = gameObject.AddComponent<GameManager>();
                }
            }

            return _instance;
        } 
    }

    private int _score = 0;
    public int Score
    {
        get { return _score; }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddScore(int point)
    {
        _score += point;
        Debug.Log($"Current Score : {Score}");
    }
}
