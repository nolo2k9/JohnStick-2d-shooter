using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    //show in unity inspector
    [System.Serializable]
   public class Wave {
       //contains how may enemies can be spawned inside this wave
       public EnemyScript[] enemies;
       //hpw many enemies can be spawned inside the wave
       public int count;
        //how length beween enemy spawns
       public float timeBetweenSpawns;

   }

   public Wave[] waves;
   public Transform[] spawnPoints;
   public float timeBetweenWaves;

   private Wave currentWave;
   private int currentWaveIndex;
   private Transform player;

   private bool isFinished;

   private void Start(){
       //finding the player by the assigned tag
       player = GameObject.FindGameObjectWithTag("Player").transform;
       //passing in the wave index into coroutine to start the wave
       StartCoroutine(StartNextWave(currentWaveIndex));
   }
    //wait an x ammount of seconds based on timeBetweenWaves and then cll another coroutine to spawn wave
   IEnumerator StartNextWave(int index){
       yield return new WaitForSeconds(timeBetweenWaves);
       StartCoroutine(SpawnWave(index));
   }
   IEnumerator SpawnWave (int index){
       currentWave = waves[index];

       for (int i = 0; i < currentWave.count; i++)
       {
           //if player is dead break from loop
           if (player == null)
           {
               yield break; 
           }

            //generate random enemy 
           EnemyScript randomEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
           //spawn in random area
           Transform randomArea = spawnPoints[Random.Range(0, spawnPoints.Length)];
           //create new random enemy in random spot on map 
           Instantiate(randomEnemy, randomArea.position, randomArea.rotation);
            //detect if current wave has ended
            // if i is equal to currentWave.count -1 
           if(i==currentWave.count -1)
           {
                isFinished = true;
           } else
           {
               isFinished = false;
           }

           //wait an allotted ammount of time 
           yield return new WaitForSeconds(currentWave.timeBetweenSpawns);

       }
   }

   //Detect when enemies have died 
   private void Update()
   {
       //if the wave has finished and no more enemys are alive inside the game wave done
       if(isFinished == true && GameObject.FindGameObjectsWithTag("Enemy").Length ==0)
       {    //new wave
           isFinished = false;
           if(currentWaveIndex + 1 < waves.Length)
           {
               currentWaveIndex ++;
               StartCoroutine(StartNextWave(currentWaveIndex));
           } else
           {
               Debug.Log("Game completed");
           }
       }
   }
}
