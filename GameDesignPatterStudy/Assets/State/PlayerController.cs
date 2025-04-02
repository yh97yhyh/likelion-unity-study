using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private StateMachine stateMachine;

    void Start()
    {
        stateMachine = new StateMachine();
        stateMachine.ChangeState(new IdleState());
    }

    void Update()
    {
        stateMachine.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(new JumpState());
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            stateMachine.ChangeState(new RunState());
        }
        else if (!Input.anyKey)
        {
            stateMachine.ChangeState(new IdleState());
        }
    }
}
