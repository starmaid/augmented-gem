using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerBaseState
{
    public PlayerInteractState(PlayerStateManager context, PlayerStateFactory states) : base(context, states)
    {
    }

    public override void CheckSwitchState()
    {
        if(_context.IsInteractEnd){
            SwitchState(_states.Move());
        }
    }

    public override void EnterState()
    {
        _context.MyAnimator.SetBool("moving", false);
    }

    public override void ExitState()
    {
        _context.CurrentSpeed = _context.WalkSpeed;
    }

    public override void FixedUpdateState()
    {
        CheckSwitchState();
        _context.IsInteractEnd = false;
    }
}
