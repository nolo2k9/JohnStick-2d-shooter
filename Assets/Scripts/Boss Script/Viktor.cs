using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viktor : MonoBehaviour
{
    public int health;
    public EnemyScript[] enemies;
    public float spawnPoint;

    private int atHalfHealth;

    public int damage;

    private Animator anim;

    private SceneChange sceneChange;

    private void Start()
    {
        atHalfHealth = health /2;
        anim = GetComponent<Animator>();
        sceneChange = FindObjectOfType<SceneChange>();
    }

    public void Damage(int damageAmount){
        //subtracting damage amount from health variable
        health -= damageAmount;
     
        //if the health is less than or equal to 0 destory the enemy object
        if(health<=0){
            Destroy(gameObject);
            sceneChange.LoadScene("WIN");

        }

        if (health <= atHalfHealth)
        {
            anim.SetTrigger("stage2");
        }

        EnemyScript randEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randEnemy, transform.position + new Vector3(spawnPoint, spawnPoint, 0), transform.rotation);
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.tag=="Player")
       {
           collision.GetComponent<Player>().Damage(damage);
       }
   }
}
