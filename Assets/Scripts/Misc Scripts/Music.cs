using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music: MonoBehaviour
{   //instance of music 
    private static Music musicInstance;

    private void Awake()
    {   //Always play music
        if(musicInstance ==null)
        {
            musicInstance = this;
            DontDestroyOnLoad(musicInstance);
        }
        else
        {   //if two instance of music are playing destroy one
            Destroy(gameObject);
            
        }//if/else

    }//Awake
   
}//Music
