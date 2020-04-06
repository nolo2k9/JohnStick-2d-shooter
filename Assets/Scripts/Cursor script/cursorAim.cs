using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorAim : MonoBehaviour
{

   
    private void Start()
    {
        
    }//Start
  

    //aim follow mouse around screen 
    private void Update()
    {   //position of cursor is the mouse position
        transform.position = Input.mousePosition;
    }//Update

}//cursorAim
