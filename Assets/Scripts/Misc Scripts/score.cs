using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class score : MonoBehaviour
{   //Initial Score value
    public static int scoreValue =0;
    //Refernece to Score text on screen
    Text scoreText;
    // Start is called before the first frame update
    void Start()
    {   //Score text will be written here
        scoreText = GetComponent<Text>();

    }//Start

    // Update is called once per frame
    void Update()
    {   //Score text value
        scoreText.text = "Score: " + scoreValue;

    }//Update

}//score
