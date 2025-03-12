using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public enum Stage
{
    First,
    Second,
    Boss
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; set; }
    private bool _isRunning;
    public bool IsRunning 
    { 
        get { return _isRunning; }
        set
        {   
            if (_isRunning == true && value == false)
            {
                StartCoroutine(DelayedFinishGame());
            }
            _isRunning = value;
        }
    }
    private Stage _curStage;
    public Stage CurStage
    {
        get { return _curStage; }
        set
        {
            if (_curStage != value)
            {
                _curStage = value;
                SpawnManager.Instance.StopRepeating();
                SpawnManager.Instance.SetSpawnRate();
            }
        }
    }

    public Text scoreText;
    public int Score { get; set; }
    public Text SituationText;

    private void Awake()
    {
        if (GameManager.Instance == null)
        {
            GameManager.Instance = this;
        }
        CurStage = Stage.First;
        IsRunning = true;
        SituationText.gameObject.SetActive(false);
    }

    private void Start()
    {
        //StartCoroutine("StartGame");
    }

    IEnumerator StartGame()
    {
        int i = 3;
        while(i > 0)
        {
            SituationText.text = i.ToString();
            yield return new WaitForSeconds(1);
            i--;
        }

        if (i == 0)
        {
            SituationText.gameObject.SetActive(false);
        }
    }

    public void AddScore(int num)
    {
        Score += num;
        scoreText.text = $"Score : {Score}";

        if (Score < 200)
        {
            CurStage = Stage.First;
        }
        else if (Score < 500)
        {
            CurStage = Stage.Second;
        }
        else
        {
            CurStage = Stage.Boss;
        }
    }

    private IEnumerator DelayedFinishGame()
    {
        yield return new WaitForSeconds(2f);
        FinishGame();
    }


    private void FinishGame()
    {
        Time.timeScale = 0f;
        SituationText.gameObject.SetActive(true);
        SituationText.text = "Game Clear!";
        Debug.Log("Game Clear!");
    }
}
