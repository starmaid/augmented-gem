using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothMovement: BasicBeast
{
    private float yOffset;
    private float xOffset;

    protected override void Start()
    {
        base.Start();
        flipTimer = 2;
        animTimer = 0;
        moveSpeed = 1.5f;
        xOffset = 0; //
        yOffset = 0; //
    }

    public override IEnumerator Transmute()
    {
        StartCoroutine(base.Transmute());

        //calculate the fall with gravity to give it more weight
        myRigidBody.gravityScale = 9.8f;
        yield return new WaitForSeconds(0.1f);
        myRigidBody.gravityScale = 0;
        myRigidBody.velocity = Vector3.zero;
        Debug.Log("transmute called in MothMovement.cs");
        Debug.Log("isenabled:" + isEnabled);
    }
//i just lost the game
    // Update is called once per frame
    void Update()
    {

        if (isEnabled)
        {
            animTimer += Time.deltaTime;

            if (animTimer > 0.1)
            {
                animTimer = 0;
                mySpriteRenderer.sprite = GetNextTex();
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
