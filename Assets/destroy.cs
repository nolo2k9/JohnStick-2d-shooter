﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    public float life;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life);
    }

   
}
