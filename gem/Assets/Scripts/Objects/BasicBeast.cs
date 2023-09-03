using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBeast : ITransmutable
{
    [Header("Golding")]
    [SerializeField] public Material goldMaterial;
    // protected TriggerInteract interactState;
    // public AudioSource transmuteSFX;
    // protected bool isEnabled;
  
    // protected SpriteRenderer mySpriteRenderer;

    // protected Transmutable myTransmutable;

    [Header("Animation")]
    [SerializeField] public List<Sprite> texFrames;
    protected int tex_index = 0;

    [Header("Movement")]
    public Rigidbody2D myRigidBody;
    // private bool isEnabled;
    protected float flipTimer;
    protected float animTimer;
    protected float moveTimer;
    protected float moveDirectionAngle;
    protected Vector3 moveDirection;
    protected float moveSpeed;
    protected bool isMoving;

    protected virtual void Start()
    {
        isEnabled = true;
        // myTransmutable = GetComponent<Transmutable>();
        myRigidBody = GetComponent<Rigidbody2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        interactState = GetComponent<TriggerInteract>();
        // mySpriteRenderer = myTransmutable.SpriteRenderer;
        // isEnabled = myTransmutable.IsEnabled;
    }

    // public virtual IEnumerator Transmute(){
    //     // yield return new WaitForSeconds(0f);
    //     if (isEnabled){
    //         isEnabled = false;
    //         mySpriteRenderer.material = goldMaterial;
    //         interactState.isEnabled = true;
    //         this.gameObject.tag="interactable";
    //         transmuteSFX.Play();
    //         yield return new WaitForSeconds(transmuteSFX.clip.length);
    //         // StartCoroutine(Transmute());
    //         myRigidBody.velocity = Vector3.zero;
    //         isMoving = false;
    //         // isEnabled = myTransmutable.IsEnabled;
    //     }
    // }

    protected virtual Sprite GetNextTex(){
        tex_index++;
        if (tex_index >= texFrames.Count)
        {
            tex_index = 0;
        }
        return texFrames[tex_index];
    }

    public override IEnumerator Transmute()
    {
        if (isEnabled){
            isEnabled = false;
            mySpriteRenderer.material = goldMaterial;
            interactState.isEnabled = true;
            this.gameObject.tag="interactable";
            transmuteSFX.Play();
            yield return new WaitForSeconds(transmuteSFX.clip.length);
            // StartCoroutine(Transmute());
            myRigidBody.velocity = Vector3.zero;
            isMoving = false;
            // isEnabled = myTransmutable.IsEnabled;
        }
    }
}
