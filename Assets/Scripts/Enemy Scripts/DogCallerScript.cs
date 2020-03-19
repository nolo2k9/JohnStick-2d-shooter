using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCallerScript : EnemyScript
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // store the position of the selected area on the map he will spawn dogs
    private Vector2 targetPosition;
    //reference to animator attached to dog caller so animations can be changed
    private Animator anim;
    //how much time the character must take before he can call a dog again
    public float timeBetweenSummons;
    //
    private float summonTime;
    //EnenyScript variable
    public EnemyScript enemyToSummon;
    //overriting start function from EnemyScript
    public override void Start()
    {   //calling start function from EnemyScript
        base.Start();
        //create a random number between these two float variables
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        //setting target position to the random number generated between these two variables
        targetPosition = new Vector2(randomX, randomY);
        //reference to animator script
        anim = GetComponent<Animator>();

    }

    private void Update()
    {
        //making sure the player is still alive 
        if(player != null)
        {
            //if the current positon and targetposition are more than 0.5px apart, move closer
            if (Vector2.Distance(transform.position, targetPosition) > .5f)
            {   //move towards target position
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                //play the running animation
                anim.SetBool("isRunning", true);
            //if the target position has been reached 
            }else {
                //change set isRunning to false whihc will call the idle animation
                anim.SetBool("isRunning", false);

                if(Time.time >= summonTime){
                    summonTime = Time.time + timeBetweenSummons;
                    //set the summon animation
                    anim.SetTrigger("summon");
                }
            }
        }
    }

    public void callDogs(){
        //if player is still alive
        if(player != null){
            Instantiate(enemyToSummon, transform.position, transform.rotation);

        }

    }

}
