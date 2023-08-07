// using System.Collections;
// using System.Collections.Generic;
// using System.Transactions;
using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{   
    //defines different types of player states
    walk, //idle, walk animation
    transmute,
    interact,
    push,
    stagger
}

public enum MovementAxis
{
    horizontal,
    vertical,
    all
}

public class PlayerMovement : MonoBehaviour
{

    public PlayerState currentState;
    public float walkSpeed;
    public float slowSpeed;
    private float currentSpeed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private SpriteRenderer mySpriteRenderer;
    private PlayerControls playerControls; //new input system
    // private Transform intCollision;
    private Collider2D myCollider;
    public GameObject rayPoint;
    [SerializeField] float rayDistance;
    private MovementAxis myAxis = MovementAxis.all;
    

    //public FloatValue currentHealth;
    //public SignalSender playerHealthSignal;
    //public VectorValue StartingPosition;
    
    //public Inventory playerInventory;
    //public SpriteRenderer receivedItemSprite;

    public SignalSO interactSignal;

    private void Awake(){
        playerControls = new PlayerControls();  
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        currentState = PlayerState.walk;
        myRigidbody = GetComponent<Rigidbody2D>(); 
        currentSpeed = walkSpeed;
        myCollider = GetComponent<Collider2D>();

        playerControls.Adventurer.Transmute.performed += ctxt => OnTransmute();
        playerControls.Adventurer.Transmute.canceled += _ =>{
            animator.SetBool("transmuting",false);
            currentState = PlayerState.walk;
        };
        playerControls.Adventurer.Interact.canceled += _ =>{
            animator.SetBool("pushing",false);
            currentSpeed = walkSpeed;
            currentState = PlayerState.walk;
            myAxis = MovementAxis.all;
            myRigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
        };
    }

    //OnXXX functions are called once after the action is activated (through user input)
    private void OnMove(InputValue value){
        change = value.Get<Vector2>();
    }

    private void OnInteract()
    {
        interactSignal.Raise();
    }

    private void OnTransmute(){
        animator.SetBool("moving", false);
        animator.SetBool("transmuting",true);
        currentState = PlayerState.transmute;
    }

    private void OnInteract(){
        if (checkObject() == "interactable"){
            Debug.Log("interacted!");
        }
    }

    private void OnPush(){

        if(Math.Abs(animator.GetFloat("moveX") + animator.GetFloat("moveY")) == 1 && checkObject() == "pushable"){
            //raise an interactable signal for the object itself
                animator.SetBool("pushing",true);
                currentState = PlayerState.push;
                currentSpeed = slowSpeed;
                if(animator.GetFloat("moveX") != 0 && animator.GetFloat("moveY") == 0){
                    myAxis = MovementAxis.horizontal;
                }else if (animator.GetFloat("moveY") != 0 && animator.GetFloat("moveX") == 0){
                    myAxis = MovementAxis.vertical;
                }
                Debug.Log("pushed!");
        }
    }

    // checks if the player can interact with any object. if yes, return its tag. else return empty string
    private String checkObject(){
        String tag = "";
        Vector2 startPos = rayPoint.transform.position;
        Vector2 endPos = startPos + new Vector2(animator.GetFloat("moveX"),animator.GetFloat("moveY")) * rayDistance;
        RaycastHit2D hit = Physics2D.Linecast(startPos,endPos, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider!=null){
            // Debug.DrawLine(startPos,endPos,Color.red);
            if(hit.collider.CompareTag("interactable")){
                tag = "interactable";
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

    // Start is called before the first frame update
    // Will use later
    void Start()
    {
        //animator.SetFloat("moveX", 0);
        //animator.SetFloat("moveY", -1);
        //transform.position = StartingPosition.initialValue;
        //this is just so that at the beginning of the game, the animator
        //has a reference on what the state is before player moved
    }
    
    //called when this script is Enable/Disable'd
    void OnEnable(){
        playerControls.Enable();
    }

    void OnDisable(){
        playerControls.Disable();
    }

    //linecast drawn are only for debug purposes
    //Delete later
    void Update(){
        Vector2 startPos = rayPoint.transform.position;
        Vector2 endPos = startPos + new Vector2(animator.GetFloat("moveX"),animator.GetFloat("moveY")) * rayDistance;
        RaycastHit2D hit = Physics2D.Linecast(startPos,endPos, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider!=null){
            if(hit.collider.CompareTag("interactable")){
                Debug.DrawLine(startPos,endPos,Color.yellow);
            }
            if(hit.collider.CompareTag("pushable")){
                Debug.DrawLine(startPos,endPos,Color.red);
            }
            // Debug.Log("hits: " + hit.collider.name);
        }
        else{
            Debug.DrawLine(startPos,endPos,Color.green);
        }
    }

    // Update is called once per frame
    // Check PlayerState and determine what to do
    void FixedUpdate()
    {
        //Debug.Log("state: " + currentState);
        // Debug.Log("state: " + currentState);
        if (currentState == PlayerState.interact)
        {
            animator.SetBool("moving", false);
        }else if (currentState == PlayerState.transmute){
            if (change != Vector3.zero){
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
            }
            TurnGoldCo();
        }else if (currentState == PlayerState.push){
            PushAnimationAndMove();
        }else{
            UpdateAnimationAndMove();
        }
    }

    //Transmute Coroutine
    void TurnGoldCo(){
        //TODO
    }

    //Handles Push Animation & direction
    void PushAnimationAndMove(){
        if (change != Vector3.zero)
        {
            if (myAxis == MovementAxis.horizontal){
                myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
            }else if(myAxis == MovementAxis.vertical){
                myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
            MoveCharacter();
            animator.SetBool("moving", true);   
        }
        else
        {
            animator.SetBool("moving", false);
            return;
        }
    }

    //Handles Move Animation
    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
            return;
        }
    }


    void MoveCharacter()
    {         
        // changeVector = new Vector3(change.x,change.y,0);
        myRigidbody.MovePosition
        (
            transform.position + 2 * currentSpeed * Time.fixedDeltaTime * change
        //make sure framerate drop doesnt affect distance
        );
    }

}

