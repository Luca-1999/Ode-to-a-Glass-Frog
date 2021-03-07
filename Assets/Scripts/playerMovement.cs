using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator anim;
    public float runSpeed = 40f;
    public AudioSource wS;
    public AudioSource jS;
    bool isGrounded;
    private audioC audioCont;

    float hMotion = 0;
    bool jump = false;
    public bool dJump = false;//double jump bool
    bool canDoubleJump;
    bool rStep = false;

    private void Awake()
    {
        //controller = GetComponent<CharacterController2D>();
        isGrounded = controller.isGrounded;
        audioCont = audioC.instance;
    }

    // called a fixed amount of tiems per second, used to get
    //player input
    void Update()
    {
        
        //returns value between -1 and 1, determined by user input
        hMotion = Input.GetAxisRaw("Horizontal")*runSpeed;
        anim.SetFloat("Speed", Mathf.Abs(hMotion));

        if (controller.isGrounded && dJump)
        {
            Debug.Log("can double jummp");
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            //jump = true;
            //anim.SetBool("IsJumping", true);
            if (controller.isGrounded || canDoubleJump) {
                Debug.Log("jumping and " + canDoubleJump);
                jump = true;
                anim.SetBool("IsJumping", true);
                canDoubleJump = canDoubleJump && !controller.isGrounded ? false : canDoubleJump;
            }   
        }
        controller.Move(hMotion * Time.fixedDeltaTime, jump);
        jump = false;
    }

    //if condition is met play audio source
    //if repeat, then audio source will play once again
    [System.Obsolete("making use of animation events for sound")]
    void checkPlaySound(bool cond, audioC.Sounds s)
    {

        if (cond)
        {
            if (!audioCont.isPlaying(s))
            {
                //consider creating walk bool and only play audio after jump has been checked
                audioCont.Play(s);
            }
        }
        else
        {
            audioCont.Stop(s);
        }

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
        Debug.Log("jump is: " + jump);
        if (jump)
        {
            Debug.Log("playing jumping sound");
            audioCont.Play(audioC.Sounds.pJump);
        }
    }
}
