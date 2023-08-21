public class PlayerStateFactory
{
    protected PlayerStateManager _context;

    public PlayerStateFactory(PlayerStateManager ctxt){
        _context = ctxt;
    }

    public PlayerBaseState Move(){
        return new PlayerMoveState(_context,this);
    }
    public PlayerBaseState Interact(){
        return new PlayerInteractState(_context,this);
    }
    public PlayerBaseState Push(){
        return new PlayerPushState(_context,this);
    }
    public PlayerBaseState Transmute(){
        return new PlayerTransmuteState(_context,this);
    }
    public PlayerBaseState Stagger(){
        return new PlayerStaggerState(_context,this);
    }
}
