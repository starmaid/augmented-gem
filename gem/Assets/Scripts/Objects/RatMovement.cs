using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement: BasicBeast
{
    protected override void Start()
    {
        base.Start();
        flipTimer = 2;
        animTimer = 0;
        moveSpeed = 1.5f;
    }

    void Update()
    {

        if (isEnabled)
        {
            animTimer += Time.deltaTime;

            if (animTimer > 0.1) //added isMoving
            {
                animTimer = 0;
                mySpriteRenderer.sprite = GetNextTex();
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

                myRigidBody.velocity = moveDirection * moveSpeed;
            }
            else
            {
                myRigidBody.velocity = Vector3.zero;
                flipTimer -= Time.deltaTime;
                if (Random.value > 0.997)
                {
                    mySpriteRenderer.flipX = !mySpriteRenderer.flipX;
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
                        mySpriteRenderer.flipX = false;
                    }
                    else
                    {
                        mySpriteRenderer.flipX = true;
                    }
                }
            }
        }
    }
}
