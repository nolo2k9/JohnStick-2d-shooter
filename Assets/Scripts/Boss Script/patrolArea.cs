using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class patrolArea : StateMachineBehaviour
{
    //Speed variable
    public float speed;
    //Referneces to selected patrol points on canvas
    private GameObject[] patrolPoints;
    //this variable will be randomised so the patrol point where the boss goes to to changes everytime
    int randomPoint;

    // When the boss enters
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Assigning the patrolPoints variable to objects that have the "patrolPoints" tag
        patrolPoints = GameObject.FindGameObjectsWithTag("patrolPoints");
        //Assigning the the randomPoint variable to a number between 0 and the number of patrol points
        randomPoint = Random.Range(0, patrolPoints.Length);
	}

    //The boss moving
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Moving the boss between the patrol points array at a chosen speed
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, patrolPoints[randomPoint].transform.position, speed * Time.deltaTime);
        //Ensures the boss gets to a distance 0.1f from the patrol point before moving again
        if (Vector2.Distance(animator.transform.position, patrolPoints[randomPoint].transform.position) < 0.1f)
        {   //move the boss again if the distance has been reached
            randomPoint = Random.Range(0, patrolPoints.Length);
        }

    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

    
}
