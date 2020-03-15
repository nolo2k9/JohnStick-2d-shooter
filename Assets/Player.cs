using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{  //dictate how fast the player will move a
   public float speed;

   private Rigidbody2D rBody;

   private Animator animator;

   private Vector2 moveAmount;

   public int health;
    //array of images 
   public Image[] healthUI;
   public Sprite fullHealth;
   public Sprite emptyHealth;

   public Animator hurtAnimation;
   private SceneChange sceneChange;

   private void Start()
   {   
        //attaching animator component to player character
        animator = GetComponent<Animator>();
    
       //setting rBody to the rigidbody 2d component which is attached to the player character 
       rBody = GetComponent<Rigidbody2D>();
       sceneChange = FindObjectOfType<SceneChange>();
   }
   //gets called everyframe of the game
   private void Update()
   {
       Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
       moveAmount = moveInput.normalized * speed;
        /*
            check wheather the player is moving 
            If the player is moving call the isRunning parameter 
            to transition them from idle to run
        */
       if(moveInput!= Vector2.zero)
       {
           animator.SetBool("isRunning", true);
        //if the character is not moving transition back to idle animation
       }else{
           animator.SetBool("isRunning", false);
       }
   }

   private void FixedUpdate()
   {
       rBody.MovePosition(rBody.position + moveAmount * Time.fixedDeltaTime);
   }

   public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
        UpdateHealthUI(health);
        hurtAnimation.SetTrigger("hurt");
        //if the health is less than or equal to 0 destory the enemy object
        if(health<=0){
            Destroy(gameObject);
            sceneChange.LoadScene("DEAD");

        }
   }

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

   }

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
      
   }


}
