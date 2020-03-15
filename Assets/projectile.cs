using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
   public float speed;
   public float lifeTime;
   public GameObject explosion;
   public GameObject soundObject;
   public int damage;
  

   private void Start()

   {
       Invoke("DestroyProjectile", lifeTime);
       Instantiate(soundObject, transform.position, transform.rotation);
     
   }

   private void Update()
   {
       transform.Translate(Vector2.right  * speed * Time.deltaTime);
   }

   private void DestroyProjectile()
   {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
   }
    //stores object that has been collided with 
   private void OnTriggerEnter2D(Collider2D collision){
       //if the enemys tag is collided with 
       if(collision.tag =="Enemy")
       {
           collision.GetComponent<EnemyScript>().Damage(damage);
           DestroyProjectile();
       }

         if(collision.tag =="Viktor")
       {
           collision.GetComponent<Viktor>().Damage(damage);
           DestroyProjectile();
       }



   }
}
