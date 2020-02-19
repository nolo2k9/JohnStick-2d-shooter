using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //refernace to players transform component, so script knows what to follow
    public Transform playerTransform;
    public float speed;

    public float minX;
    public float maxX;
    public float miny;
    public float maxY;

    private void Start()
    {   //camera position = playersPosition
        transform.position = playerTransform.position;
    }

    //update every frame in the camera position to be equal to the players position
    //Lerp is a function that lets you move (smoothly) from one point to another based on a speed
    //Takes in current position , the player position and a speed value
    private void Update()
    {
        //if the player transform exists. The player will die in the game, if its not in an if an error message will appear
        if(playerTransform != null){
            float clampedX = Mathf.Clamp(playerTransform.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerTransform.position.y, miny, maxY);
            transform.position = Vector2.Lerp(transform.position, new Vector2(clampedX, clampedY), speed);
        }
        
    }


}

