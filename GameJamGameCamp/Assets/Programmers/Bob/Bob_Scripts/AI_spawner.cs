using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_spawner : MonoBehaviour
{

   
   
    public GameObject[] Enemies;
    
    public bool spawnEnemies;
    public int roundNumber;
    public float MaxRad;
    
    void Start()
    {
    }
    void Update()
    {
        if (spawnEnemies)
        {
            for (int i = 0; i < ((roundNumber * 10)); i++)
            {
                Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * MaxRad;
                
                NavMeshHit hit;

                NavMesh.SamplePosition(randomDirection, out hit, MaxRad, 1);
                Vector3 finalPosition = hit.position; // Finnally have dis rando pointo

                var Rando = UnityEngine.Random.Range(0, (Enemies.Length));
                Instantiate(Enemies[Rando], hit.position, Enemies[Rando].transform.rotation);

            }
            spawnEnemies = false;
        }
      
    }

    

   

   
    


}