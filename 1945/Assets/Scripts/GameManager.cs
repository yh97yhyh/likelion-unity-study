using UnityEngine;

public enum Stage
{
    First,
    Second,
    Boss
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Stage _curStage;
    public Stage CurStage
    {
        get { return _curStage; }
        set
        {
            if (_curStage != value)
            {
                _curStage = value;
            }
        }
    }

    public int DropedItemCnt = 0;

    public float AttackPower = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        CurStage = Stage.First;
    }
}
