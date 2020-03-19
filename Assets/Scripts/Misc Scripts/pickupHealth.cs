using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupHealth : MonoBehaviour
{
    Player player;
    public int healthAmount;
    public GameObject soundObject;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       
     
    }
    //detect collisions 
  private void OnTriggerEnter2D(Collider2D isCollision)
  {     //if an entity with the player tag collides 
        if (isCollision.tag == "Player")
        {
            player.HealPlayer(healthAmount);
            Instantiate(soundObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
  }
}
