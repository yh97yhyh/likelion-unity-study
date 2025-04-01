using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    public Text HealthText;
    public GameObject GameOver;

    void Start()
    {
        SetListener();
        SetUI();
    }

    private void SetListener()
    {
        EventManager.Instance.AddListsner("PlayerHealthChanged", OnPlayHealthChanged);
        EventManager.Instance.AddListsner("PlayerDied", OnPlayerDied);
    }

    private void SetUI()
    {
        HealthText.text = "HP: 50";
        GameOver.SetActive(false);
    }

    private void OnPlayHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI Update : Player hp is changed to {health}.");

        HealthText.text = $"HP: {health}";
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI Update : Player is died!");

        GameOver.SetActive(true);
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener("PlayerHealthChanged", OnPlayHealthChanged);
        EventManager.Instance.RemoveListener("PlayerDied", OnPlayerDied);
    }
}

