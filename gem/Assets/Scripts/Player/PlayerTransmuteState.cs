using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransmuteState : PlayerBaseState
{
    private IBeast _beast;
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
        Vector2 startPos = _context.RayPoint.transform.position;
        Vector2 endPos = startPos + new Vector2(_context.MyAnimator.GetFloat("moveX"),_context.MyAnimator.GetFloat("moveY")) * _context.RayDistance;
        RaycastHit2D hit = Physics2D.Linecast(startPos,endPos, 1 << LayerMask.NameToLayer("Raycast Detectable"));
        Debug.DrawLine(startPos,endPos,Color.magenta);
        if (hit.collider != null){
            if (hit.collider.CompareTag("transmutable")){
                _beast = hit.collider.GetComponent<IBeast>();
                // Debug.Log("check this beast!" + (_beast!=null));
                if(_beast.IsEnabled){
                    _beast.StartCoroutine(_beast.transmute());
                }
            }
        }
    }

}
