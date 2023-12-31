using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    
    public PlayerMoveState(PlayerStateManager context, PlayerStateFactory states) : base(context, states)
    {
    }

    public override void CheckSwitchState()
    {
        // check if transmute is pressed
        if (_context.IsTransmutingPressed)
            SwitchState(_states.Transmute());
        else if (_context.IsInteractingPressed && _context.CheckObject() == "interactable"){
            // if we press interact, we need to call the interact method of our context
            _context._interactObj.InteractTrigger();
            
        } else if (StoryManager.GetInstance().dialogueIsPlaying) {
            // if we step on a story tile, lets just go straight into interact state
            SwitchState(_states.Interact());

        } else if (_context.IsPushingPressed && _context.CheckObject() == "pushable"){
            SwitchState(_states.Push());

        } else if (_context.IsTransmutingPressed){
            SwitchState(_states.Transmute());
        }
    }

    public override void EnterState()
    {
    }

    public override void ExitState()
    {
        _context.MyAnimator.SetBool("moving",false);
    }

    public override void FixedUpdateState()
    {
        // if (_context.IsActive){
            UpdateAnimationAndMove();
            CheckSwitchState();  
        // }else{
        //     _context.MyAnimator.SetBool("sit",true);
        // }
    }

    public void UpdateAnimationAndMove()
    { 

        if (_context.Change != Vector3.zero)
        {
            _context.MoveCharacter();
            _context.MyAnimator.SetFloat("moveX", _context.Change.x);
            _context.MyAnimator.SetFloat("moveY", _context.Change.y);
            _context.MyAnimator.SetBool("moving", true);
        }
        else
        {
            _context.MyAnimator.SetBool("moving", false);
            return;
        }
    }
    // void MoveCharacter()
    // {         
    //     // changeVector = new Vector3(change.x,change.y,0);
    //     _context.MyRigidBody.MovePosition
    //     (
    //         _context.transform.position + 2 * _context.CurrentSpeed * Time.fixedDeltaTime * _context.Change
    //     //make sure framerate drop doesnt affect distance
    //     );
        
    // }
}
