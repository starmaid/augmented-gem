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
        if (_context.Change != Vector3.zero){
            _context.MyAnimator.SetFloat("moveX", _context.Change.x);
            _context.MyAnimator.SetFloat("moveY", _context.Change.y);
        }
        HandleTransmute();
        CheckSwitchState();
    }

    public void HandleTransmute(){
        if (_context.CheckObject() == "transmutable"){
            _context.BeastObj.StartCoroutine(_context.BeastObj.transmute()); //if it aint monobehavior it dont let me start coroutine. pretty bs
            // Debug.Log("Transmuting!" + _context.BeastObj);
        }
    }
}
