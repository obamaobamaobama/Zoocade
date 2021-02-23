using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] box;
    public Transform[] spawnSpots;
    public float[] rot;
    public float setTime;
    [SerializeField]
    private float coolDown;
    public bool readyToSpawn;
    public void FixedUpdate()
    {
         if (coolDown <= 0)
        {
        int randPos = Random.Range(0, spawnSpots.Length);
        int randBox = Random.Range(0, box.Length);
        int randRot = Random.Range(0,rot.Length);
        Instantiate(box[randBox], spawnSpots[randPos].position, Quaternion.Euler(0,0,rot[randRot]));
        readyToSpawn = false;
        coolDown = setTime;
        }
         else if(readyToSpawn)
        {
            coolDown -= Time.deltaTime;
        }
           
    }
    public void zReadyToSpawn()
    {
        readyToSpawn = true;
    }
    
}
