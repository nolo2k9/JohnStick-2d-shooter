using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highscore : MonoBehaviour
{   //Variable to handle the Highscore value
    private int highscoreValue;
    //Refernece to Text area on canvas
    Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        //Assigning highScoreText to the component called Text
        highScoreText = GetComponent<Text>();
        //Output highsocre to string. PlayerPrefsallows the socre to hold on the machine 
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        
    }//Start

    // Update is called once per frame
    void Update()
    {
        //if the score is greater than the current highscore
        if (score.scoreValue > PlayerPrefs.GetInt("Highscore", 0))
        {    //Create a new highscore with this highscore value
             highscoreValue = score.scoreValue;
             PlayerPrefs.SetInt("Highscore", highscoreValue);
             highScoreText.text = "New High Score: " + highscoreValue.ToString();
        }//if
        
       
    }//Update

    
}//highscore
