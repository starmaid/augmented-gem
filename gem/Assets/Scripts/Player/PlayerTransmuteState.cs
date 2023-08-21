using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransmuteState : PlayerBaseState
{
    public PlayerTransmuteState(PlayerStateManager context, PlayerStateFactory states) : base(context, states)
    {
    }

    public override void CheckSwitchState()
    {   
        if (!_context.IsTransmutingPressed){
            SwitchState(_states.Move());
        }
    }

    public override void EnterState()
    {
        _context.MyAnimator.SetBool("moving", false);
        _context.MyAnimator.SetBool("transmuting",true);
    }

    public override void ExitState()
    {
        _context.MyAnimator.SetBool("transmuting",false);
    }

    public override void FixedUpdateState()
    {
        _context.MyAnimator.SetFloat("moveX", _context.Change.x);
        _context.MyAnimator.SetFloat("moveY", _context.Change.y);
        HandleTransmute();
        CheckSwitchState();
    }

    public void HandleTransmute(){
        Debug.Log("Imagine I'm transmuting right now oooo");
    }
}
