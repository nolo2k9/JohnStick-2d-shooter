using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class highscore : MonoBehaviour
{
    private int highscoreValue;
    Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText = GetComponent<Text>();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("Highscore", 0).ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score.scoreValue > PlayerPrefs.GetInt("Highscore", 0))
        {
             highscoreValue = score.scoreValue;
             PlayerPrefs.SetInt("Highscore", highscoreValue);
             highScoreText.text = "New High Score: " + highscoreValue.ToString();
        }
        
       
    }

    
}
