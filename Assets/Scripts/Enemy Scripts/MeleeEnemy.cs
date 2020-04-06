using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyScript //Derived from enemy script
{   //Enemy will chase player until it has reached stop distance
    public float stopDistance;
    //Variable to handle attack time
    private float attackTime;
    //Variable to handle attack speed
    public float attackSpeed;

    private void Update()
    {   //if player is not = null(dead)
        if(player!=null){
            //if the enemy distance is to far away from the player 
            if(Vector2.Distance(transform.position, player.position)>stopDistance){
                //move towards players position
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }else{
                //if the time is greater than the attack time
                if(Time.time >= attackTime){
                    //call attack method from enemyScript
                    StartCoroutine(Attack());
                    //Setting up attack time variable assigning it to Time.time + timeBetween attacks
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }//if/else
        }//if
    }//update
    //get player component call the damage function and deal x amount of damage
    IEnumerator Attack(){
        player.GetComponent<Player>().Damage(damage);
        //position of melee enemy before he leaps towards the player 
        Vector2 originalPosition = transform.position;
        //leap towards the players current position
        Vector2 targetPosition = player.position;
        //how much of animation has been done. 
        float percent = 0;
        while(percent <=1){
            //acts as a counter, every frame it will add a little bit to the percent variable 
            percent += Time.deltaTime * attackSpeed;
            //Speed enemy moves towards player during attack
            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            //Move towards the target position(The players position) from the current postion at a speed held in formula
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }//while

    }//Attack

}//MeleeEnemy
