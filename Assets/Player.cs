using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{  //dictate how fast the player will move a
   public float speed;

   private Rigidbody2D rBody;

   private Animator animator;

   private Vector2 moveAmount;

   private void Start()
   {   
        //attaching animator component to player character
        animator = GetComponent<Animator>();
    
       //setting rBody to the rigidbody 2d component which is attached to the player character 
       rBody = GetComponent<Rigidbody2D>();
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

}
