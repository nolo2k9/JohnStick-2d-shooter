using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //reference to players transform component, so script knows what to follow
    public Transform playerTransform;
    //Speed Variable
    public float speed;
    //variables to handle the minimum and maximum x and y points
    public float minX;
    public float maxX;
    public float miny;
    public float maxY;

    private void Start()
    {   //camera position = playersPosition
        transform.position = playerTransform.position;
    }//Start method

    //update every frame in the camera position to be equal to the players position
    //Lerp is a function that lets you move (smoothly) from one point to another based on a speed
    //Takes in current position , the player position and a speed value
    //References to clamp and lerp functions in readme
    private void Update()
    {
        //if the player transform exists. The player will die in the game, if its not in an if an error message will appear
        if(playerTransform != null){
            //Assiging the minimum and maximum X points
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            //Assiging the minimum and maximum Y points
            float clampedY = Mathf.Clamp(playerTransform.position.y, miny, maxY);
            //Setting the camera up to follow the player to the specified x and y points and a selected speed
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }//if
        
    }//Update


}//CameraFollow

