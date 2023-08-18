using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPushState : PlayerBaseState
{
    public enum MoveAxis
    {
        horizontal,
        vertical,
        all
    }

    private MoveAxis _myAxis;
    public PlayerPushState(PlayerStateManager context, PlayerStateFactory states) : base(context, states)
    {
    }


    public override void CheckSwitchState()
    {
        if(!_context.IsPushingPressed){
            SwitchState(_states.Move());
        }
    }

    public override void EnterState()
    {
        if(_context.MyAnimator.GetFloat("moveX") != 0 && _context.MyAnimator.GetFloat("moveY") == 0){
            _myAxis = MoveAxis.horizontal;
        }else if (_context.MyAnimator.GetFloat("moveY") != 0 && _context.MyAnimator.GetFloat("moveX") == 0){
            _myAxis = MoveAxis.vertical;
        }
        _context.MyAnimator.SetBool("pushing",true);
        _context.CurrentSpeed = _context.SlowSpeed;

    }

    public override void ExitState()
    {
        _context.MyAnimator.SetBool("pushing",false);
        _context.CurrentSpeed = _context.WalkSpeed;
        _myAxis = MoveAxis.all;
        _context.MyRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public override void FixedUpdateState()
    {

        if (_context.Change != Vector3.zero)
        {
            if (_myAxis == MoveAxis.horizontal){
                 _context.MyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }else if(_myAxis == MoveAxis.vertical){
                _context.MyRigidBody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            _context.MoveCharacter();
            _context.MyAnimator.SetBool("moving", true);   
        }
        else
        {
            _context.MyAnimator.SetBool("moving", false);
            // return;
        }
        CheckSwitchState();
    }
}
