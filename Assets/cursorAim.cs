﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorAim : MonoBehaviour
{

    //hide cursor
    private void Start()
    {
        
    }
  

    //aim follow mouse around screen 
    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
