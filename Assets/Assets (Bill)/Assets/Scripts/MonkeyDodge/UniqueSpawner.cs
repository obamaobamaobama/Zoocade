using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniqueSpawner : MonoBehaviour
{
   public GameObject airEnemy;
   public GameObject groundEnemy;
   public Transform airSp;
   public Transform groundSp;
   public float timeBtwSpawns;
   public float timerSet;
   public float timerSetMax;
   public bool spawnGroundEnemy;
    
    void FixedUpdate()
    {
        timeBtwSpawns -= Time.deltaTime;
        int randomEnemy = Random.Range(0,2);
        float timerRandomness = Random.Range(0,timerSetMax);

        if(timeBtwSpawns <= 0 && randomEnemy == 0)
        {
            Instantiate(groundEnemy, groundSp.position, Quaternion.identity);
            timeBtwSpawns = timerSet + timerRandomness;
        }
        if(timeBtwSpawns <= 0 && randomEnemy == 1)
        {
            Instantiate(airEnemy, airSp.position, Quaternion.identity);
            timeBtwSpawns = timerSet + timerRandomness;
        }
    }
}
