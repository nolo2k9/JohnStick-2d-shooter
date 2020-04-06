using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viktor : MonoBehaviour
{
    //Health Variable
    public int health;
    //Reference to enemy script
    public EnemyScript[] enemies;
    //Spawn points
    public float spawnPoint;
    //Variable for action when boss reaches half health
    private int atHalfHealth;
    //Damage to hold damage
    public int damage;
    //Reference to Animator object
    private Animator anim;
    //refernece to sceneChange object
    private SceneChange sceneChange;

    //Start method
    private void Start()
    {
        // Making the variable 'atHalfHealth' equal to half of the initial health
        atHalfHealth = health /2;
        //Assigning the variable 'anim' to the Animator object
        anim = GetComponent<Animator>();
        //Assigning sceneChange to object SceneChange which will call that relevant script
        sceneChange = FindObjectOfType<SceneChange>();
    }//Start

    //  Method to control the damage
    public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
     
        //if the boss health is less than or equal to 0 destory the boss object
        if(health<=0){
            //destroy boss object
            Destroy(gameObject);
            //Load the win scene
            sceneChange.LoadScene("WIN");

        }
        //if the bosses health is less than or equal to the variable "atHalfHealth"
        if (health <= atHalfHealth)
        {   //Call the stage2 animation 
            anim.SetTrigger("stage2");
        }
        //References EnemyScript which will be called and will call a random enemy
        EnemyScript randEnemy = enemies[Random.Range(0, enemies.Length)];
        //Call a random enemy at a random position and spawn point
        Instantiate(randEnemy, transform.position + new Vector3(spawnPoint, spawnPoint, 0), transform.rotation);
   }//Damage

   //Method to handle hat happens if the player collides with the boss
   private void OnTriggerEnter2D(Collider2D collision)
   {    //if the object that collides with the boss has the 'Player' tag
       if (collision.tag=="Player")
       {   //Call the player damage function
           collision.GetComponent<Player>().Damage(damage);
       }
   }//OnTriggerEnter2D

}//Viktor

