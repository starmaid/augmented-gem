using UnityEngine;

//The base State switching class
public abstract class PlayerBaseState
{
    protected PlayerStateManager _context;
    protected PlayerStateFactory _states;
    //by having context we dont have to repetitively pass it in every time we need to switch state

    public PlayerBaseState(PlayerStateManager context,PlayerStateFactory states){
        _context = context;
        _states = states;
    }

    public abstract void EnterState();
    public abstract void FixedUpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchState();

    protected void SwitchState(PlayerBaseState newState){
        ExitState();
        // Debug.Log("exiting: " + _context.CurrentState);
        newState.EnterState();
        _context.CurrentState = newState;
        Debug.Log("entering: " + _context.CurrentState);
    }

}
