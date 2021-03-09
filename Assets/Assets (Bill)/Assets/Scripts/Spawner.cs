using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnSpots;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float setTime = 0.6f;

    void Start()
    {
        // resets time to a value from the inspector
        timeBtwSpawns = startTimeBtwSpawns;
    }

    void FixedUpdate()
    {
        // when timer run to 0 spawn enemy in a random spawnSpots. when there is still time, -= Time.deltatime. After spawning, the timer resets to 2
        if (timeBtwSpawns <= 0)
        {
            int randPos = Random.Range(0, spawnSpots.Length);
            int randEn = Random.Range(0, enemy.Length);
            Instantiate(enemy[randEn], spawnSpots[randPos].position, Quaternion.identity);
            timeBtwSpawns = setTime;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
