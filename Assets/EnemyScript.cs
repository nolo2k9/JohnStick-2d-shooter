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
   
    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
        //if the health is less than or equal to 0 destory the enemy object
        if(health<=0){
            Destroy(gameObject);
        }


    }
}
