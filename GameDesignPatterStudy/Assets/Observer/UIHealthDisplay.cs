using UnityEngine;

public class UIHealthDisplay : MonoBehaviour
{
    void Start()
    {
        EventManager.Instance.AddListsner("PlayerHealthChanged", OnPlayHealthChanged);
        EventManager.Instance.AddListsner("PlayerDied", OnPlayerDied);
    }

    private void OnPlayHealthChanged(object data)
    {
        int health = (int)data;
        Debug.Log($"UI Update : Player hp is changed to {health}.");

        // UI 업데이트
    }

    private void OnPlayerDied(object data)
    {
        Debug.Log("UI Update : Player is died!");

        // 게임 오버 화면 표시
    }

    private void OnDestroy()
    {
        EventManager.Instance.RemoveListener("PlayerHealthChanged", OnPlayHealthChanged);
        EventManager.Instance.RemoveListener("PlayerDied", OnPlayerDied);
    }
}
