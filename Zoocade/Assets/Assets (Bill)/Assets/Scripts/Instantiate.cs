using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{

    public int maxEnemies = 11;
    public Transform[] sp;
    public GameObject[] enemy;
       void Start()
    {
        for(int i = 0; i < maxEnemies; i++)
        {
            int randEn = Random.Range(0,enemy.Length);
            int spawning = i;
             Instantiate(enemy[randEn], sp[spawning].position, Quaternion.Euler(0,0,0));
        }
        
    }
    
    
}
