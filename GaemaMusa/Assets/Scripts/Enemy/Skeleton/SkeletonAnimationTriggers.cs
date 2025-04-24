using UnityEngine;

public class SkeletonAnimationTriggers : MonoBehaviour
{

    private Skeleton skeleton;

    void Awake()
    {
        skeleton = GetComponentInParent<Skeleton>();
    }

    private void AnimationFinishTrigger()
    {
        skeleton.AnimationFinishTrigger();
    }

    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(skeleton.attackCheck.position, skeleton.attackCheckRadius); // 범위 안에 있는 모든 Collider를 가져옴

        foreach (var hit in colliders)
        {
            //if (hit.GetComponent<Player>() != null)
            //{
            //    hit.GetComponent<Player>().TakeDamage();
            //}
            PlayerStats target = hit.GetComponent<PlayerStats>();
            skeleton.stats.DoDamage(target);
        }
    }

    protected void OpenCounterWindow()
    {
        skeleton.OpenCounterAttackWindow();
    }

    protected void CloseCounterWindow()
    {
        skeleton.CloseCounterAttackWindow();
    }
}
