using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
   //speed of projectile
   public float speed;
   //how long will projectile live
   public float lifeTime;
   //Refernece to gameobject explosion
   public GameObject explosion;
   //Refernece to gameobject explosion
   public GameObject soundObject;
   //Amount of damage
   public int damage;
  

   private void Start()

   {   //call destory projectile and start the lifetime
       Invoke("DestroyProjectile", lifeTime);
       //Instantiate from shot point and call soundobject 
       Instantiate(soundObject, transform.position, transform.rotation);
     
   }//Start

   private void Update()
   {    //Where the projectile comes from 
       transform.Translate(Vector2.right  * speed * Time.deltaTime);
   }//Update

   private void DestroyProjectile()
   {    //explosion particles position 
        Instantiate(explosion, transform.position, Quaternion.identity);
        //Destroy the game object
        Destroy(gameObject);

   }//DestroyProjectile
    //stores object that has been collided with 
   private void OnTriggerEnter2D(Collider2D collision){
       //if the enemys tag is collided with 
       if(collision.tag =="Enemy")
       {    //call the enemy damage method
           collision.GetComponent<EnemyScript>().Damage(damage);
           //destory the projectile
           DestroyProjectile();
       }

         if(collision.tag =="Viktor")
       {    //call the viktor damage method
           collision.GetComponent<Viktor>().Damage(damage);
            //destory the projectile
           DestroyProjectile();

       }//if



   }//OnTriggerEnter2D

}//projectile
