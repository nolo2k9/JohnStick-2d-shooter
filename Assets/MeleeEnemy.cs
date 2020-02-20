using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : EnemyScript
{   //Enemy will chase player until it has reached stop distance
    public float stopDistance;

    private float attackTime;

    public float attackSpeed;

    private void Update()
    {   //if player is not = null(dead)
        if(player!=null){
            //if the enemy distance is to far away from the player 
            if(Vector2.Distance(transform.position, player.position)>stopDistance){
                //move towards player
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }else{
                if(Time.time >= attackTime){
                    StartCoroutine(Attack());
                    attackTime = Time.time + timeBetweenAttacks;
                }
            }
        }
    }
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

            float formula = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector2.Lerp(originalPosition, targetPosition, formula);
            yield return null;
        }

    }
}
