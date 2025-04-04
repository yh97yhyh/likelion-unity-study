using UnityEngine;

public class PlayerAnimaEvents : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }

    public void FinishAttackTrigger()
    {
        player.FinishAttack();
    }
}
