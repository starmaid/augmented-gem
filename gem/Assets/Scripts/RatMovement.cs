using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement: MonoBehaviour
{
    private float flipTimer;
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
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            moveTimer -= Time.deltaTime;
            if (moveTimer < 0)
            {
                moveTimer = 0;
                isMoving = false;
                flipTimer = Random.value * 4;
            }

            transform.position += moveDirection * moveSpeed * Time.deltaTime;
            //rigidBody2d.velocity = Vector3.zero;

        } else
        {
            flipTimer -= Time.deltaTime;
            if (flipTimer < 0)
            { 
                flipTimer = 0;
                isMoving = true;
                moveTimer = Random.value * 2;
                moveDirectionAngle = Random.value * 2 * Mathf.PI;
                moveDirection = new Vector3(Mathf.Cos(moveDirectionAngle), Mathf.Sin(moveDirectionAngle), 0);
            }

            if (Random.value > 0.996)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

        }
    }
}
