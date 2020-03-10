using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int health;
    [HideInInspector]
    public Transform player;

    public float speed;

    public float timeBetweenAttacks;

    public int damage;
    // odds of enemy droping a pickup
    public int pickupOdds;
    public GameObject[] pickups;
   
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
        //if the health is less than or equal to 0 destory the enemy object
        if(health<=0){
            //101 because the last number is excluded
            int randomNum = Random.Range(0, 101);

            if (randomNum < pickupOdds)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                //create a random pickup atht he enemys final position 
                Instantiate(randomPickup, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }


    }
}
