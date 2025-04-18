using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeSkillController : MonoBehaviour
{
    [SerializeField] private GameObject hoetKeyPrefab;
    [SerializeField] private List<KeyCode> keyCodeList;

    public float maxSize;
    public float growSpeed;
    public bool canGrow;

    private bool canAttack;
    public int attackAmount = 5;
    public float cloneAttackCooldown = 0.3f;
    private float cloneAttackTimer;

    public List<Transform> targets = new List<Transform>();

    void Update()
    {
        cloneAttackTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            canAttack = true;
        }

        if (cloneAttackTimer < 0 && canAttack)
        {
            cloneAttackTimer = cloneAttackCooldown;
            int randomIndex = Random.Range(0, targets.Count);

            SkillManager.Instance.clone.CreateClone(targets[randomIndex]);

            attackAmount--;

            if (attackAmount <= 0)
            {
                canAttack = false;
            }
        }

        if (canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTime(true);

            CreateHotKey(collision);
        }
    }

    private void CreateHotKey(Collider2D collision)
    {
        if (keyCodeList.Count <= 0)
        {
            Debug.LogWarning("키등록 까먹었는지 체크");
            return;
        }

        GameObject newHotKey = Instantiate(hoetKeyPrefab, collision.transform.position + new Vector3(0, 1.5f), Quaternion.identity);

        KeyCode choosenKey = keyCodeList[Random.Range(0, keyCodeList.Count)];
        keyCodeList.Remove(choosenKey);

        BlackholeHotKeyController newHotKeyScript = newHotKey.GetComponent<BlackholeHotKeyController>();

        newHotKeyScript.SetupHotKey(choosenKey, collision.transform, this);

        //targets.Add(collision.transform);
    }

    public void AddEnemyToList(Transform _enemyTransofrm)
    {
        targets.Add(_enemyTransofrm);
    }
}
