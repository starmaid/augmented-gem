using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class BasicBeast : MonoBehaviour
{
    protected Transmutable myTransmutable;
    [SerializeField] public List<Sprite> texFrames;
    protected int tex_index = 0;

    // [SerializeField] public Material goldMaterial;
    // private TriggerInteract interactState;
    // protected bool isEnabled;
    // public bool IsEnabled {get{return isEnabled;}}

    protected SpriteRenderer mySpriteRenderer;
    public Rigidbody2D myRigidBody;
    // private bool isEnabled;
    protected float flipTimer;
    protected float animTimer;
    protected float moveTimer;
    protected float moveDirectionAngle;
    protected Vector3 moveDirection;
    protected float moveSpeed;
    protected bool isMoving;
    public bool isEnabled;

    // protected SpriteRenderer spriteRenderer;
    // protected Rigidbody2D rigidBody2d;
    // public BasicBeast(float fTimer, float mSpeed, float aTimer){
    //     myTransmutable = new Transmutable();
    //     // flipTimer = 2;
    //     // moveSpeed = 1.5f;
    //     // animTimer = 0; 
    //     flipTimer = fTimer;
    //     moveSpeed = mSpeed;
    //     animTimer = aTimer;   
    //     RigidBody2d = myTransmutable.RigidBody2d;
    //     isEnabled = myTransmutable.IsEnabled;
    // }

    protected virtual void Start()
    {
        myTransmutable = GetComponent<Transmutable>();
        // myTransmutable.Awake();
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = myTransmutable.SpriteRenderer;
        // mySpriteRenderer = GetComponent<SpriteRenderer>();
        isEnabled = myTransmutable.IsEnabled;
        // Debug.Log("Awake is called from BasicBeast.cs, isenabled = " + isEnabled);

        // myTransmutable = new Transmutable();

        // spriteRenderer = GetComponent<SpriteRenderer>();
        // rigidBody2d = GetComponent<Rigidbody2D>();
        // interactState = GetComponent<TriggerInteract>();
        // transmuteSFX = Resources.Load<AudioSource>("Audio/SFX/Player/transmute.wav");
        // isMoving = false;
        // isEnabled = true;
        // flipTimer = 2;
        // moveSpeed = 1.5f;
        // animTimer = 0;   
    }

    public virtual IEnumerator Transmute(){
        yield return new WaitForSeconds(0f);
        if (myTransmutable.IsEnabled){
            StartCoroutine(myTransmutable.Transmute());
            myRigidBody.velocity = Vector3.zero;
            isMoving = false;
            isEnabled = myTransmutable.IsEnabled;
            Debug.Log("transmute called in BasicBeast.cs, isenabled = " + isEnabled);
        }
    }

    protected virtual Sprite getNextTex(){
        tex_index++;
        if (tex_index >= texFrames.Count)
        {
            tex_index = 0;
        }

        return texFrames[tex_index];
    }




}
