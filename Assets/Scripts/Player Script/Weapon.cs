using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    //variable to handle what progectile to spawn
    public GameObject projectile;
    //from where does the bullet coem from
    public Transform shotPoint;
    //How much time should be taken between shots
    public float timeBetweenShots;
    //time to shoot another bullet
    private float shotTime;


   
    // Update is called once per frame
   private void Update()
    {
        //Callculating the the current mouse position to the current weapon position
        //Input.mouse position returns a screenpoint
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = rotation;

        //if the left mouse button is pressed
        if(Input.GetMouseButton(0)){
            
            //if the current time in the game is greater than the shot time
            if (Time.time >= shotTime)
            {
                //shoot projectile
                Instantiate(projectile, shotPoint.position, transform.rotation);
                //recalculate shot time current time + time between shots
                shotTime = Time.time + timeBetweenShots;
            }

        }
    }
}
