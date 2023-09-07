using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//Keeps track of the various context that is needed for State Switching
public class PlayerStateManager : MonoBehaviour
{

    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    //STATE CONTEXTS
    private bool _isMovingPressed = false;
    private bool _isTransmutingPressed = false;
    private bool _isPushingPressed = false;
    private bool _isInteractingPressed = false;
    private bool _isInteractEnd = false; //dont love how this is made but it works
    private bool _isStaggeringPressed = false;
    

    [Header("Movement Parameters")]
    [SerializeField] float _walkSpeed;
    [SerializeField] float _slowSpeed;
    private float _currentSpeed;
    public VectorValue StartingPosition;

    //ANIMATION
    private Animator _animator;
    private SpriteRenderer _mySpriteRenderer;
    // private bool _isActive;

    //PHYSICS & COLLISIONS
    private Rigidbody2D _myRigidbody;
    private Vector3 _change;
    private Collider2D _myCollider;
    [SerializeField] GameObject _rayPoint;
    [SerializeField] float _rayDistance;

    //INPUTS
    private PlayerInput _playerInput;
    public PlayerControls _playerControls; //new input system

    //INTERACTING OBJECTS
    private Pushable _pushedObj;
    // private IBeast _beast;
    public TriggerInteract _interactObj;

    //AUDIO
    private AudioSource _myAudioSource;
    
    //SIGNALS
    public SignalSO InteractSignal;

    //HIGHLIGHTS
    private SpriteSelectComponent _spriteSelectComponent;

    private GameObject _currentHit;
    private String _currentHitTag;


    //GETTERS AND SETTERS
    public PlayerBaseState CurrentState{get{return _currentState;} set{_currentState = value;}}
    public PlayerStateFactory States{get{return _states;}}
    public bool IsMovingPressed {get{return _isMovingPressed;} set{_isMovingPressed = value;}}
    public bool IsTransmutingPressed {get{return _isTransmutingPressed;} set{_isTransmutingPressed = value;}}
    public bool IsPushingPressed {get{return _isPushingPressed;} set{_isPushingPressed = value;}}
    public bool IsInteractingPressed {get{return _isInteractingPressed;} set{_isInteractingPressed = value;}}
    public bool IsInteractEnd{get{return _isInteractEnd;} set{_isInteractEnd = value;}}
    public bool IsStaggeringPressed {get{return _isStaggeringPressed;} set{_isStaggeringPressed = value;}}
    public float WalkSpeed{get{return _walkSpeed;}}
    public float SlowSpeed{get{return _slowSpeed;}}
    public float CurrentSpeed{get{return _currentSpeed;} set{ _currentSpeed = value;}}
    public Animator MyAnimator{get{return _animator;}}
    public SpriteRenderer MySpriteRenderer{get{return _mySpriteRenderer;}}
    // public bool IsActive {get{return _isActive;} set{_isActive = value;}}
    public Rigidbody2D MyRigidBody{get{return _myRigidbody;}}
    public Vector3 Change{get{return _change;} set{_change = value;}}
    public Collider2D MyCollider{get{return _myCollider;} set{_myCollider = value;}}
    // public  MovementAxis MyAxis {get{return _myAxis;} set{_myAxis = value;}}

    public GameObject RayPoint {get{return _rayPoint;}}
    public float RayDistance {get{return _rayDistance;}}
    public GameObject CurrentHit {get{return _currentHit;} set{_currentHit = value;}}
    // public IBeast BeastObj{get{return _beast;} set{_beast = value;}}

    public AudioSource MyAudioSource{get{return _myAudioSource;} set{_myAudioSource = value;}}

    // Start is called before the first frame update
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerControls = new PlayerControls();  
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _states = new PlayerStateFactory(this);
        _currentState = _states.Move();//creates interact state and pass it in thru factory
        _currentState.EnterState(); //passing in context
        // _isActive = true;
        _myRigidbody = GetComponent<Rigidbody2D>(); 
        _currentSpeed = _walkSpeed;
        _myCollider = GetComponent<Collider2D>();
        _myAudioSource = GetComponent<AudioSource>();
        transform.position = StartingPosition.initialValue;
    }

    void Start(){
        _playerControls.Adventurer.Move.performed += ctxt => Move(ctxt);
        _playerControls.Adventurer.Move.canceled += ctxt => Move(ctxt);
        _playerControls.Adventurer.Transmute.performed += ctxt => Transmute(ctxt);
        _playerControls.Adventurer.Transmute.canceled += ctxt => Transmute(ctxt);
        _playerControls.Adventurer.Push.performed += ctxt => Push(ctxt);
        _playerControls.Adventurer.Push.canceled += ctxt => Push(ctxt);
        _playerControls.Adventurer.Interact.performed += ctxt => Interact(ctxt);
        _playerControls.Adventurer.Interact.canceled += ctxt => Interact(ctxt);
        // _playerControls.Adventurer.Stagger.performed += ctxt => Stagger(ctxt);
        // _playerControls.Adventurer.Stagger.canceled += ctxt => Stagger(ctxt);
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if(_playerControls.Adventurer.enabled){
            _currentState.FixedUpdateState();   
        }else if (_playerControls.Gem.enabled){
            // Debug.Log("it gem time and it gemed all over the place");   
        }
    }
    void Update(){
        Vector2 startPos = _rayPoint.transform.position;
        Vector2 endPos = startPos + new Vector2(_animator.GetFloat("moveX"),_animator.GetFloat("moveY")) * _rayDistance;
        RaycastHit2D hit = Physics2D.Linecast(startPos,endPos, 1 << LayerMask.NameToLayer("Raycast Detectable"));
        if (hit.collider!=null){
            // Debug.Log("currenthit: " + _currentHit + "  hit.collider: " + hit.collider.GameObject());

            if(hit.collider.CompareTag("interactable")){
                Debug.DrawLine(startPos,endPos,Color.yellow);
            }
            else if(hit.collider.CompareTag("pushable")){
                Debug.DrawLine(startPos,endPos,Color.red);
            }
            else{
                Debug.DrawLine(startPos,endPos,Color.green);
            }
        }
        else{
            Debug.DrawLine(startPos,endPos,Color.green);
        }

        //EXPECTED BEHAVIOR
        // if current obj is different from hit obj
            // disable current obj (if it exist and has selectable component to disable)
            // update current obj to hit obj. if object exist, check for tags and component
            // enable new current obj (if it has selectable component)
        // if current obj is the same to hit obj
            // if it's selectable and an object  + obj and hit obj have different tags???
                //try enable current obj. again

        if (_currentHit != hit.collider.GameObject()){
            if (_currentHit != null && _spriteSelectComponent != null){
                // Debug.Log("disable current obj (if it exist and has selectable component to disable)");
                _spriteSelectComponent.tryDisable();
            }
            // Debug.Log("update current obj to hit obj");
            _currentHit = hit.collider.GameObject();
            if (_currentHit!= null){
                _spriteSelectComponent = _currentHit.GetComponent<SpriteSelectComponent>();
                _currentHitTag = _currentHit.tag;
            }
            if(_currentHit!= null && _spriteSelectComponent != null){
                // Debug.Log("enable new current obj");
                _spriteSelectComponent.tryEnable();
            }

        }else{
            // Debug.Log("currenthit: " + _currentHit.tag + "  hit.collider: " + hit.collider.GameObject().tag);
            if (_currentHit != null && _spriteSelectComponent != null &&  _currentHitTag != hit.collider.GameObject().tag){
                // Debug.Log(" if it's selectable and an object  + obj and hit obj have different tags, enable it");
                _spriteSelectComponent.tryEnable();
            }
        }
    }
    //ACTIONS
    private void Move(InputAction.CallbackContext context)
    {
        // Debug.Log("moving still on");
        _change = context.ReadValue<Vector2>();
        
    }

    private void Transmute(InputAction.CallbackContext context){
        _isTransmutingPressed = context.ReadValueAsButton();
        // Debug.Log("updated Transmute Context: " + _isTransmutingPressed);
    }

    void Interact(InputAction.CallbackContext context){
        _isInteractingPressed = context.ReadValueAsButton();

        // only call on key DOWN
        if (_isInteractingPressed)
        {
            // When walking around, this should check the object to see if we can do something
            // Usually enter dialogue mode
            InteractSignal.Raise();
            

        }
        
    }

    //CHECKS IF THE ADV CAN INTERACT WITH A NEAREST ITEM
    public String CheckObject()
    {
        String tag = "";
        Vector2 startPos = _rayPoint.transform.position;
        Vector2 endPos = startPos + new Vector2(_animator.GetFloat("moveX"), _animator.GetFloat("moveY")) * _rayDistance;
        RaycastHit2D hit = Physics2D.Linecast(startPos, endPos, 1 << LayerMask.NameToLayer("Raycast Detectable"));
        if (hit.collider != null)
        {
            // Debug.DrawLine(startPos,endPos,Color.red);
            if (hit.collider.CompareTag("interactable"))
            {
                tag = "interactable";
                _interactObj = hit.collider.GetComponent<TriggerInteract>();
            }
            if (hit.collider.CompareTag("pushable"))
            {
                tag = "pushable";
                // _pushedObj = hit.collider.GetComponent<Pushable>();
            }
            // if (hit.collider.CompareTag("transmutable")){
            //     tag = "transmutable";
            //     _beast = hit.collider.GetComponent<IBeast>();
            //     // Debug.Log("check this beast!" + (_beast!=null));
            // }
            return tag;
        }
        else
        {
            return tag;
        }
    }

    private void Push(InputAction.CallbackContext context){
        _isPushingPressed = context.ReadValueAsButton();
    }

    private void Stagger(InputAction.CallbackContext context){
        //TODO
    }

    

    //ENABLES AND DISABLES PLAYERCONTROLS
    void OnEnable(){
        _playerControls.Adventurer.Enable();
    }

    void OnDisable(){
        _playerControls.Adventurer.Disable();
    }

    //MOVES
    public void MoveCharacter()
    {         
        _myRigidbody.MovePosition
        (
            transform.position + 2 * _currentSpeed * Time.fixedDeltaTime * _change
        );
    }

    void PlayWalkSound()
    {
        if (_myAudioSource != null){
            _myAudioSource.Play();
        }
    }

    public void SwitchToGemMode(){
        // SeizeAdvControl();
        // _playerInput.actions.FindActionMap("Gem").Enable();
        // _playerInput.actions.FindActionMap("Adventurer").Disable();
        _playerControls.Adventurer.Disable();
        _playerControls.Gem.Enable();
        _playerInput.SwitchCurrentActionMap("Gem");
        Debug.Log("SwtichedToGemMode is ran. active actionmaps: " + _playerInput.currentActionMap);
        // _currentState = _states.GemWiggle();
        
    }

    public void SwitchToAdvMode(){
        _playerControls.Gem.Disable();
        _playerControls.Adventurer.Enable();
        _playerInput.SwitchCurrentActionMap("Adventurer");
        Debug.Log("SwtichedToGemMode is ran. active actionmaps: " + _playerInput.currentActionMap);
        // _currentState = _states.Move();
    }

    public void SeizeAdvControl(){
        _playerControls.Adventurer.Disable();
    }

    public void ReturnAdvControl(){
        _playerControls.Adventurer.Enable();
    }
}
