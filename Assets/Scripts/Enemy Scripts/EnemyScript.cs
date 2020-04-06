using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{   //Health variable
    public int health;
    //Player
    [HideInInspector]
    public Transform player;
    //Speed variable
    public float speed;
    //variable to handle time between enemy attacks
    public float timeBetweenAttacks;
    //Variable to handle amount of damage dealt
    public int damage;
    //odds of enemy droping a pickup
    public int pickupOdds;
    //Reference to pickups game object
    public GameObject[] pickups;
    //Variable to handle stop distance from enemy to player
    public float stopDistance;
    //Variable to handle time of attacks
    private float attackTime;
     //Variable to handle speed of attacks
    public float attackSpeed;
   
    public virtual void Start()
    {   //assigning variable player to the object witht the tag "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }//Start


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
        }//if/else
    }//Update

    public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
        //if the health is less than or equal to 0 destory the enemy object
        if(health<=0){
            //101 because the last number is excluded
            int randomNum = Random.Range(0, 101);
            //if the random number is less than the odds of droping a pickup
            if (randomNum < pickupOdds)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                //create a random pickup at the enemys final position 
                Instantiate(randomPickup, transform.position, transform.rotation);
            }
            //if the enemys health is less than or equal to 0 give the player a score of 10
            score.scoreValue += 10;
            //destory the enemy object
            Destroy(gameObject);
        }//if


    }//Damage


    //get player component call the damage function and deal x amount of damage
    IEnumerator Attack(){
        //Calling player damage function
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

    }//Atack

}//EnemyScript
