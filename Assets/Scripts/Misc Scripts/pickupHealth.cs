using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHealth : MonoBehaviour
{
    //Reference to player object
    Player player;
    //Variable to handle how much health is given
    public int healthAmount;
    //Reference to the sound played
    public GameObject soundObject;

    private void Start()
    {
        //Assigning the player tag to the gameobject with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }//Start

//detect collisions 
  private void OnTriggerEnter2D(Collider2D isCollision)
  {     //if an entity with the player tag collides with the health 
        if (isCollision.tag == "Player")
        {   //call the HealPlayer method health will be updated by the assigned heal amount
            player.HealPlayer(healthAmount);
            //Call the sound, instantiate at the position 
            Instantiate(soundObject, transform.position, transform.rotation);
            //destroy the health object
            Destroy(gameObject);
        }
  }//OnTriggerEnter2D

}//pickupHealth
