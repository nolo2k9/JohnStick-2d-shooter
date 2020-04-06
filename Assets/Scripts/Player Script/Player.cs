using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{  //dictate how fast the player will move 
   public float speed;
   //Reference to Rigidbody
   private Rigidbody2D rBody;
   //Reference to Animator
   private Animator animator;
   //Vector2 moveAmount
   private Vector2 moveAmount;
   //Variable handles health
   public int health;
    //array of images 
   public Image[] healthUI;
   //full health sprite
   public Sprite fullHealth;
    //empty health sprite
   public Sprite emptyHealth;
   //Refernece to hurtAnimation 
   public Animator hurtAnimation;
   //Refernece to sceneChange
   private SceneChange sceneChange;

   private void Start()
   {   
       
       score.scoreValue =0;

        //attaching animator component to player character
        animator = GetComponent<Animator>();
    
       //setting rBody to the rigidbody 2d component which is attached to the player character 
       rBody = GetComponent<Rigidbody2D>();
       //SceneChange
       sceneChange = FindObjectOfType<SceneChange>();

   }//Start

   //gets called everyframe of the game
   private void Update()
   {
       Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       //Assigning the player move amount to  moveInput.normalized * speed assigned 
       moveAmount = moveInput.normalized * speed;
        /*
            check wheather the player is moving 
            If the player is moving call the isRunning parameter 
            to transition them from idle to run
        */
        //if player is moving 
       if(moveInput!= Vector2.zero)
       {   //run this animation
           animator.SetBool("isRunning", true);
        //if the character is not moving transition back to idle animation
       }else{
           //run idle animation
           animator.SetBool("isRunning", false);

       }//if/else

   }//Update

   private void FixedUpdate()
   {   //Move the players position
       rBody.MovePosition(rBody.position + moveAmount * Time.fixedDeltaTime);

   }//FixedUpdate

   public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
        //Update the health on the ui accordingly
        UpdateHealthUI(health);
        //call the hurt animation
        hurtAnimation.SetTrigger("hurt");
        //if the health is less than or equal to 0 destory the enemy object
        if(health<=0){
            //destory player object
            Destroy(gameObject);
            //change scene to dead Scene
            sceneChange.LoadScene("DEAD");
            
        }//if

   }//Damage

   void UpdateHealthUI(int currentHealth){
       /*
            if i is less than current health
            hearts[i] = full health 
       */
       for(int i =0; i<healthUI.Length; i++)
       {
            if (i<currentHealth)
            {
                healthUI[i].sprite = fullHealth;
            }else {
                healthUI[i].sprite = emptyHealth;
            }
       }

   }//UpdateHealthUI

   public void HealPlayer(int amountOfHealth)
   {   
       //if the health is 5 don't add more (Maxed out)
       if (health + amountOfHealth > 5 )
       {
           health = 5;
       }
       else 
       {
            //add to health 
            health += amountOfHealth;
       }

        //update the health UI with new health amount 
       UpdateHealthUI(health);
      
   }//HealPlayer


}//Player
