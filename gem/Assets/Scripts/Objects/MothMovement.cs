using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothMovement: BasicBeast
{
    // [SerializeField] public List<Sprite> texFrames;
    // private int tex_index = 0;

    // [SerializeField] public Material goldMaterial;
    // protected SpriteRenderer spriteRenderer;
    // public Rigidbody2D rigidBody2d;
    // private bool isEnabled;

    // private float flipTimer;
    // private float animTimer;
    // private float moveTimer;
    // private float moveDirectionAngle;
    // private Vector3 moveDirection;
    // private float moveSpeed;
    // private BasicBeast myBeast;

    private float yOffset;
    private float xOffset;

    // public MothMovement() : base(2, 0, 1.5f)
    // {
        // spriteRenderer = base.myTransmutable.SpriteRenderer;
        // rigidBody2d = base.myTransmutable.RigidBody2d;
        // isEnabled = base.myTransmutable.IsEnabled;
    // }

    // private SpriteRenderer spriteRenderer;
    // private Rigidbody2D rigidBody2d;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        // myTransmutable = GetComponent<Transmutable>();
        // // myTransmutable.Awake();
        // myRigidBody = GetComponent<Rigidbody2D>();
        // mySpriteRenderer = myTransmutable.SpriteRenderer;
        // // mySpriteRenderer = GetComponent<SpriteRenderer>();
        // isEnabled = myTransmutable.IsEnabled;
        // this = new MothMovement(2f,0f,1.5f);
        flipTimer = 2;
        animTimer = 0;
        moveSpeed = 1.5f;
        xOffset = 0;//
        yOffset = 0;//
    }

    public override IEnumerator Transmute()
    {
        StartCoroutine(base.Transmute());
        // rigidBody2d.velocity = Vector3.zero;
        // isEnabled = false;
        // spriteRenderer.material = goldMaterial;

        myRigidBody.gravityScale = 9.8f;
        //calculate the fall with gravity to give it more weight
        yield return new WaitForSeconds(0.1f);
        myRigidBody.gravityScale = 0;
        myRigidBody.velocity = Vector3.zero;
        Debug.Log("transmute called in MothMovement.cs");
        Debug.Log("isenabled:" + isEnabled);
    
        // this.gameObject.tag="interactable";
        // GetComponent<TriggerInteract>().isEnabled = true;
        // transmuteSFX.Play();
        // yield return new WaitForSeconds(transmuteSFX.clip.length);
    }

    // protected override Sprite getNextTex()
    // {
    //     tex_index++;
    //     if (tex_index >= texFrames.Count)
    //     {
    //         tex_index = 0;
    //     }

    //     return texFrames[tex_index];
    // }

    // Update is called once per frame
    void Update()
    {
        //if (isEnabled && Time.time > 5)
        //{
        //    StartCoroutine(transmute());
        //}

        if (isEnabled)
        {
            animTimer += Time.deltaTime;

            if (animTimer > 0.1)
            {
                animTimer = 0;
                mySpriteRenderer.sprite = getNextTex();
            }

            xOffset = Mathf.Sin(Time.time * 10) * 2f;
            yOffset = Mathf.Sin(Time.time * 6) * 2f;

            if (isMoving)
            {
                moveTimer -= Time.deltaTime;
                if (moveTimer < 0)
                {
                    moveTimer = 0;
                    isMoving = false;
                    flipTimer = 0.5f + Random.value * 4;
                }

                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
            else
            {
                myRigidBody.velocity = Vector3.zero;
                flipTimer -= Time.deltaTime;

                if (xOffset > 0)
                {
                    mySpriteRenderer.flipX = true;
                }
                else
                {
                    mySpriteRenderer.flipX = false;
                }

                if (flipTimer < 0)
                {
                    flipTimer = 0;
                    isMoving = true;
                    moveTimer = 0.2f + Random.value * 3;
                    moveDirectionAngle = Random.value * 2 * Mathf.PI;
                    moveDirection = new Vector3(Mathf.Cos(moveDirectionAngle), Mathf.Sin(moveDirectionAngle), 0);
                    if (Mathf.Cos(moveDirectionAngle) > 0)
                    {
                        mySpriteRenderer.flipX = true;
                    }
                    else
                    {
                        mySpriteRenderer.flipX = false;
                    }
                }
            }
            transform.position += new Vector3(xOffset, yOffset, 0) * Time.deltaTime;
        }
    }

}
