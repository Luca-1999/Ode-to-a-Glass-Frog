using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// reference:
// https://github.com/Brackeys/2D-Character-Controller/blob/master/CharacterController2D.cs 

public class CharMovementManager : MonoBehaviour
{
    public bool grounded = false;
    public bool airControl = false;
    private Rigidbody2D rb;
    private Vector3 tempV = Vector3.zero;
    public float smoothingFactor = 0.05f;
    private bool isRight = true;
    public float jumpF = 400f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float keyMove, bool jump, bool isGrounded)
    {
        //only want to enable control if character
        //is grounded or able to move while in 
        //the air
        if (isGrounded || airControl) {

            //determine target velocity based on movement speed
            Vector3 tVel = new Vector2(keyMove * 10f, rb.velocity.y);

            rb.velocity = Vector3.SmoothDamp(rb.velocity, tVel, ref tempV, smoothingFactor);

            //if player is facing left and moves right or player is facing
            //right and moves left, flip
            if ((keyMove > 0 && !isRight) || (keyMove < 0 && isRight))
            {
                Flip();
            }
        }

        if (jump) {
            //velocity change on jump for snappy movement
            //rb.Velocity = Vector2.up*jumpVelocity;
            rb.AddForce(new Vector2(0f, jumpF));
        }
    }

    private void Flip() {

        isRight = !isRight;
        Vector3 lScale = transform.localScale;
        lScale.x *= -1;//flip
        transform.localScale = lScale;
    }
}