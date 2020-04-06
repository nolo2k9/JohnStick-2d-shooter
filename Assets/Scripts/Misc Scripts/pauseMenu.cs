using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour
{

    public static bool isPaused = false;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }//Start

    // Update is called once per frame
    void Update()
    {   //if the key p is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {   //if the game is alread paused,resume
            if (isPaused)
            {
                Resume();
            }
            else 
            //if the game is not paused,paused
            {
                Pause();

            }//if/else

        }//if

    }//Update

    void Resume()
    {   //The game is not paued
        pauseScreen.SetActive(false);
        //Speed time passes
        Time.timeScale = 1f;
        //is pausd = false
        isPaused = false;

    }//Resume


    void Pause()
    {   //pauseScreen is active
        pauseScreen.SetActive(true);
        //Speed time passes in pause moe=de
        Time.timeScale = 0f;
        //isPaused = true
        isPaused = true;
    }//Pause

}//pauseMenu
