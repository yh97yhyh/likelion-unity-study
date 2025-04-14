using UnityEngine;

public class SwordSkill : Skill
{
    [Header("Skill Info")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private Vector2 launchDir;
    [SerializeField] private float swordGravity;

    public void CreateSword()
    {
        GameObject newSword = Instantiate(swordPrefab, player.transform.position, transform.rotation);
        SwordSkillController swordSkillController = newSword.GetComponent<SwordSkillController>();
        swordSkillController.SetupSword(launchDir, swordGravity);
    }
}
