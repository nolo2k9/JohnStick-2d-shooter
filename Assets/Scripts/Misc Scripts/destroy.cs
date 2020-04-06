using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    //Variable to handle life
    public float life;
    // Start is called before the first frame update
    void Start()
    {   //Destory the gameoject and life
        Destroy(gameObject, life);
    }//Start

   
}//Destroy
