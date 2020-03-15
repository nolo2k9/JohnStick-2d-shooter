using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music: MonoBehaviour
{
    private static Music musicInstance;

    private void Awake()
    {
        if(musicInstance ==null)
        {
            musicInstance = this;
            DontDestroyOnLoad(musicInstance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
}
