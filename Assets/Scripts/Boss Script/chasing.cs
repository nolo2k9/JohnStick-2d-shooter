using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasing : StateMachineBehaviour
{
    //Reference to the player Object
    private GameObject player;
    //Speed variable
    public float speed;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Find the object with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //if the player is still alive
        if (player != null)
        {
            //move towards the player at the specified time and speed
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, player.transform.position, speed * Time.deltaTime);
        }
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

}
