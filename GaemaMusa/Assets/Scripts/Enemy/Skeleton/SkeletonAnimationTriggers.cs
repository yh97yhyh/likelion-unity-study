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
}
