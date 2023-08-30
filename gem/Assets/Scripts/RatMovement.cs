using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement: MonoBehaviour
{
    [SerializeField] public List<Sprite> texFrames;
    private int tex_index = 0;

    [SerializeField] public Material goldMaterial;

    private bool isEnabled;

    private float flipTimer;
    private float animTimer;
    private float moveTimer;
    private float moveDirectionAngle;
    private Vector3 moveDirection;
    private float moveSpeed;
    private bool isMoving;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2d;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2d = GetComponent<Rigidbody2D>();
        isMoving = false;
        flipTimer = 2;
        moveSpeed = 1.5f;
        isEnabled = true;
        animTimer = 0;
    }

    public IEnumerator transmute()
    {
        rigidBody2d.velocity = Vector3.zero;
        isEnabled = false;
        spriteRenderer.material = goldMaterial;
        GetComponent<TriggerInteract>().isEnabled = true;
        yield return new WaitForSeconds(0f);
    }

    private Sprite getNextTex()
    {
        tex_index++;
        if (tex_index >= texFrames.Count)
        {
            tex_index = 0;
        }

        return texFrames[tex_index];
    }

    // Update is called once per frame
    void Update()
    {
        //if (isEnabled && Time.time > 5)
        //{
        //    transmute();
        //}

        if (isEnabled)
        {
            animTimer += Time.deltaTime;

            if (animTimer > 0.1)
            {
                animTimer = 0;
                spriteRenderer.sprite = getNextTex();
            }

            if (isMoving)
            {
                moveTimer -= Time.deltaTime;
                if (moveTimer < 0)
                {
                    moveTimer = 0;
                    isMoving = false;
                    flipTimer = 0.5f + Random.value * 4;
                }

                //transform.position += moveDirection * moveSpeed * Time.deltaTime;
                //rigidBody2d.velocity = Vector3.zero;
                rigidBody2d.velocity = moveDirection * moveSpeed;
            }
            else
            {
                rigidBody2d.velocity = Vector3.zero;
                flipTimer -= Time.deltaTime;
                if (Random.value > 0.997)
                {
                    spriteRenderer.flipX = !spriteRenderer.flipX;
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
                        spriteRenderer.flipX = false;
                    }
                    else
                    {
                        spriteRenderer.flipX = true;
                    }
                }
            }
        }
    }
}
