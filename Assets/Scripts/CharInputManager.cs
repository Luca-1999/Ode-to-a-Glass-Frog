using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharInputManager : MonoBehaviour
{
    public CharMovementManager controller;
    public Animator anim;
    public float runSpeed = 40f;
    float hMotion = 0;
    bool jump = false;
    public bool dJump = false;//double jump bool, set by power up
    public LayerMask groundLayer;
    public LayerMask enemyLayer;

    private bool canDoubleJump = false;
    private bool isJumpSound = false;
    private bool rStep = false;
    private audioC audioCont;
    private Rigidbody2D rb;
    private EdgeCollider2D edgeCol;
    private bool wasGroudned = true;

    private void Awake()
    {
        //controller = GetComponent<CharacterController2D>();
        audioCont = audioC.instance;
        rb = GetComponent<Rigidbody2D>();
        edgeCol = transform.GetComponent<EdgeCollider2D>();
    }

    // called a fixed amount of tiems per second, used to get
    //player input
    void Update()
    {
        // check grounded only really needs to be called a single time

        //returns value between -1 and 1, determined by user input
        //allows for smoother movement
        hMotion = Input.GetAxisRaw("Horizontal")*runSpeed;
        anim.SetFloat("Speed", Mathf.Abs(hMotion));

        if (checkGrounded() && dJump)
        {
            //Debug.Log("can double jummp");
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (checkGrounded())
            {
                isJumpSound = true;
                jump = true;
                anim.SetBool("IsJumping", true);
            }   else if (canDoubleJump) {
                isJumpSound = true;
                jump = true;
                //resets jump animation on double jump
                anim.Play("Base Layer.Player_jump", -1, 0f);
                //anim.SetBool("IsJumping", true);
                canDoubleJump = false;
            }
        }

        // old implementation, kept temporarily for reference
        //if (Input.GetButtonDown("Jump")) {
        //    if (checkGrounded()) {
        //        isJumpSound = true;
        //        jump = true;
        //        anim.SetBool("IsJumping", true);
        //    } else {
        //        //double jump pressed only if key is pressed on frame
        //        if (Input.GetButtonDown("Jump")){
        //            if (canDoubleJump) {
        //                isJumpSound = true;
        //                jump = true;
        //                //resets jump animation on double jump
        //                anim.Play("Base Layer.Player_jump", -1, 0f);
        //                //anim.SetBool("IsJumping", true);
        //                canDoubleJump = false;
        //            }
        //        }
        //    } 
        //}

        //can guard this call by is grounded if air control
        //is to be denied
        controller.Move(hMotion * Time.fixedDeltaTime, jump, checkGrounded());
        jump = false;
    }

    //used to apply player input
    private void FixedUpdate()
    {
        //multiplied by the amount of time since function last called
        //move same amount no matter how often it's called
        //controller.Move(hMotion * Time.fixedDeltaTime, jump);
        //jump = false; //double jump?
    }

    //alternates steps whenever called by animation event
    public void stepSound() {
        if (rStep)
        {
            audioCont.Play(audioC.Sounds.rStep);
        }
        else {
            audioCont.Play(audioC.Sounds.lStep);
        }
        rStep = !rStep;   
    }

    public void jumpSound() {
        Debug.Log("playing jumping sound");
        if (isJumpSound)
        {
            Debug.Log("playing jumping sound");
            audioCont.Play(audioC.Sounds.pJump);
            isJumpSound = false;
        }
    }

    // check grounded with box cast using player's edge collider as a reference
    private bool checkGrounded()
    {
        //box cast from center of player edge colliter
        RaycastHit2D raycastHit3d = Physics2D.BoxCast(edgeCol.bounds.center, edgeCol.bounds.size, 0f, Vector2.down, .1f, groundLayer | enemyLayer);
        bool amGrounded = raycastHit3d.collider != null;
        //Debug.Log(amGrounded);
        if (amGrounded && !wasGroudned)// landed
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFall", false);// animaiton to be implemented
        }
        wasGroudned = amGrounded;
        return amGrounded;
    }

    //secondary option to ground check, keeps a grounded global, but is only called
    //on collision; might be more efficient
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //string s = collision.gameObject.tag;
        //collision.gameobject.tag == "terrain"
        //if (s == "terrain" || s == "enemy")
        //{
        //    Debug.Log("collided");
        //    grounded = true;
        //    anim.SetBool("IsJumping", false);
        //    anim.SetBool("IsFall", false);
        //}
    }
}
