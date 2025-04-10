using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    private Player player;

    void Awake()
    {
        player = GetComponentInParent<Player>();
    }

    private void AnimationFinishTrigger()
    {
        player.AnimationFinishTrigger();
    }
}
