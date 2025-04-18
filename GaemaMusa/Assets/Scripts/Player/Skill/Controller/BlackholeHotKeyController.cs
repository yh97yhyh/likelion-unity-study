using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BlackholeHotKeyController : MonoBehaviour
{
    private SpriteRenderer sr;
    private KeyCode myHotKey;
    private TextMeshProUGUI myText;

    private Transform myEnemy;
    private BlackholeSkillController blackhole;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        myText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetupHotKey(KeyCode _myHotKey, Transform _myEnemy, BlackholeSkillController _myBlackhole)
    {
        myEnemy = _myEnemy;
        blackhole = _myBlackhole;

        myHotKey = _myHotKey;
        myText.text = myHotKey.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(myHotKey))
        {
            blackhole.AddEnemyToList(myEnemy);

            myText.color = Color.clear;
            sr.color = Color.clear;
        }
    }
}
