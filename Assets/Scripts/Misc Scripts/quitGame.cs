using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitGame : MonoBehaviour
{
    public void quit(){
        //log the following to console
        Debug.Log("Game has been quit");
        //quit the application
        Application.Quit();
    }//quit
    
}//quitGame
