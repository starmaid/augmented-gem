using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IBeast : MonoBehaviour
{
    [SerializeField] public List<Sprite> texFrames;
    protected int tex_index = 0;

    [SerializeField] public Material goldMaterial;
    private TriggerInteract interactState;
    protected bool isEnabled;

    protected float flipTimer;
    protected float animTimer;
    protected float moveTimer;
    protected float moveDirectionAngle;
    protected Vector3 moveDirection;
    protected float moveSpeed;
    protected bool isMoving;

    protected SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigidBody2d;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2d = GetComponent<Rigidbody2D>();
        interactState = GetComponent<TriggerInteract>();
        isMoving = false;
        flipTimer = 2;
        moveSpeed = 1.5f;
        isEnabled = true;
        animTimer = 0;   
    }

    // Update is called once per frame
    protected virtual void Update(){}

    public virtual IEnumerator transmute(){
        rigidBody2d.velocity = Vector3.zero;
        isEnabled = false;
        spriteRenderer.material = goldMaterial;
        interactState.isEnabled = true;
        //change tag to interactable
        yield return new WaitForSeconds(0f);
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
