using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// called on initial boss machine state through animator
public class boss_run : StateMachineBehaviour
{
    //put this in boss script and get it from there
    Transform player;
    Rigidbody2D rb;
    boss_movement bm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        bm = animator.GetComponent<boss_movement>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //get player x, not interested in changing/considering vertical
        //position in this implementation
        //Vector2 tgt = new Vector2(player.position.x, rb.position.y);
        //Vector2 newPos = Vector2.MoveTowards(rb.position, tgt, speed * Time.fixedDeltaTime);
        //rb.MovePosition(newPos);
        bm.move(player, rb);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
