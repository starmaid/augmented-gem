// using System.Collections;
// using System.Collections.Generic;
// using System.Transactions;
using UnityEngine;
using UnityEngine.InputSystem;

public enum PlayerState
{   
    //defines different types of player states
    walk, // include walk + idel
    transmute,
    interact,
    stagger
}

public class PlayerMovement : MonoBehaviour
{

    public PlayerState currentState;
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private Animator animator;
    private SpriteRenderer mySpriteRenderer;
    private PlayerControls playerControls; //new input system
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

        // playerControls.Adventurer.Move.performed += ctxt => {
        //     Vector2 dir = ctxt.ReadValue<Vector2>();
        //     change = Vector3.zero;
        //     change.x = dir.x;
        //     change.y = dir.y;
        // };
        // playerControls.Adventurer.Move.canceled += _ =>{
        //     change = Vector3.zero;
        // };
        playerControls.Adventurer.Transmute.performed += ctxt => OnTransmute();
        playerControls.Adventurer.Transmute.canceled += _ =>{
            animator.SetBool("transmuting",false);
            currentState = PlayerState.walk;
        };
        // Debug.Log("ready!");
    }

    private void OnMove(InputValue value){
        change = value.Get<Vector2>();
    }

    private void OnInteract()
    {
        interactSignal.Raise();
    }

    private void OnTransmute(){
        currentState = PlayerState.transmute;
    }

    // Start is called before the first frame update
    void Start()
    {
        //animator.SetFloat("moveX", 0);
        //animator.SetFloat("moveY", -1);
        //transform.position = StartingPosition.initialValue;
        //this is just so that at the beginning of the game, the animator
        //has a reference on what the state is before player moved
    }
    
    void OnEnable(){
        playerControls.Enable();
    }

    void OnDisable(){
        playerControls.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Debug.Log("state: " + currentState);
        if (currentState == PlayerState.interact)
        {
            animator.SetBool("moving", false);
            return;
        }else if (currentState == PlayerState.transmute){
            if (change != Vector3.zero){
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
            }
            animator.SetBool("moving", false);
            animator.SetBool("transmuting",true);
            return;
        }else{
            UpdateAnimationAndMove();
        }
    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
            //once MoveCharacter is triggered it'll go to void MoveCharacter Method
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
            transform.position + 2 * speed * Time.fixedDeltaTime * change
        //make sure framerate drop doesnt affect distance
        );
    }

}

