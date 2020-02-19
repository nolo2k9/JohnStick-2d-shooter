﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{
   public float speed;
   public float lifeTime;
   public GameObject explosion;

   private void Start()

   {
       Invoke("DestroyProjectile", lifeTime);
       
   }

   private void Update()
   {
       transform.Translate(Vector2.right  * speed * Time.deltaTime);
   }

   private void DestroyProjectile()
   {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
   }
}
