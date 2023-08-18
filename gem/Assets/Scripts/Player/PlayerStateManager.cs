using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
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

    //ANIMATION
    private Animator _animator;
    private SpriteRenderer _mySpriteRenderer;

    //PHYSICS & COLLISIONS
    private Rigidbody2D _myRigidbody;
    private Vector3 _change;
    private Collider2D _myCollider;
    [SerializeField] GameObject _rayPoint;
    [SerializeField] float _rayDistance;

    //INPUTS
    public PlayerControls _playerControls; //new input system

    //MOVEMENT
    // private MovementAxis _myAxis = MovementAxis.all;
    
    //AUDIO
    private AudioSource _myAudioSource;
    
    //SIGNALS
    public SignalSO InteractSignal;

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
    public Rigidbody2D MyRigidBody{get{return _myRigidbody;}}
    public Vector3 Change{get{return _change;} set{_change = value;}}
    public Collider2D MyCollider{get{return _myCollider;} set{_myCollider = value;}}
    // public  MovementAxis MyAxis {get{return _myAxis;} set{_myAxis = value;}}
    public AudioSource MyAudioSource{get{return _myAudioSource;} set{_myAudioSource = value;}}

    // Start is called before the first frame update
    void Awake()
    {
        _playerControls = new PlayerControls();  
        _mySpriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _states = new PlayerStateFactory(this);
        _currentState = _states.Move();//creates interact state and pass it in thru factory
        _currentState.EnterState(); //passing in context
        _myRigidbody = GetComponent<Rigidbody2D>(); 
        _currentSpeed = _walkSpeed;
        _myCollider = GetComponent<Collider2D>();
        _myAudioSource = GetComponent<AudioSource>();
    }

    void Start(){
        _playerControls.Adventurer.Move.performed += ctxt => Move(ctxt);
        _playerControls.Adventurer.Move.canceled += ctxt => Move(ctxt);
        _playerControls.Adventurer.Transmute.performed += ctxt => Transmute(ctxt);
        _playerControls.Adventurer.Transmute.canceled += ctxt => Transmute(ctxt);
        _playerControls.Adventurer.Push.performed += ctxt => Push(ctxt);
        _playerControls.Adventurer.Push.canceled += ctxt => Push(ctxt);
        _playerControls.Adventurer.Push.performed += ctxt => Interact(ctxt);
        _playerControls.Adventurer.Push.canceled += ctxt => Interact(ctxt);
        _playerControls.Adventurer.Push.performed += ctxt => Stagger(ctxt);
        _playerControls.Adventurer.Push.canceled += ctxt => Stagger(ctxt);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        _currentState.FixedUpdateState();   
    }

    //ACTIONS
    private void Move(InputAction.CallbackContext context)
    {
        _change = context.ReadValue<Vector2>();
        
    }

    private void Transmute(InputAction.CallbackContext context){
        _isTransmutingPressed = context.ReadValueAsButton();
        // Debug.Log("updated Transmute Context: " + _isTransmutingPressed);
    }

    void Interact(InputAction.CallbackContext context){
        _isInteractingPressed = context.ReadValueAsButton() && CheckObject() == "interactable";
    }

    private void Push(InputAction.CallbackContext context){
        _isPushingPressed = context.ReadValueAsButton();
        // Debug.Log("updated Push Context: " + _isPushingPressed);
    }

    private void Stagger(InputAction.CallbackContext context){
        //TODO
    }

    //CHECKS IF THE ADV CAN INTERACT WITH A NEAREST ITEM
    public String CheckObject(){
        String tag = "";
        Vector2 startPos = _rayPoint.transform.position;
        Vector2 endPos = startPos + new Vector2(_animator.GetFloat("moveX"),_animator.GetFloat("moveY")) * _rayDistance;
        RaycastHit2D hit = Physics2D.Linecast(startPos,endPos, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider!=null){
            // Debug.DrawLine(startPos,endPos,Color.red);
            if(hit.collider.CompareTag("interactable")){
                tag = "interactable";

                TriggerInteract tryTrigger = hit.collider.GetComponent<TriggerInteract>();
                if (tryTrigger != null)
                {
                    tryTrigger.InteractTrigger();
                }
                
            }
            if(hit.collider.CompareTag("pushable")){
                tag = "pushable";
            }
            return tag;
        }
        else{
            return tag;
        }
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
}
