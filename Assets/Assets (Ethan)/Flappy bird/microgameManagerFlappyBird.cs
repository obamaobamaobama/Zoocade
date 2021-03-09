using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microgameManagerFlappyBird : MonoBehaviour
{
    public float pipeMovespeed;
    public GameObject pipe;

    private void Start()
    {
        SpawnPipe();
    }

    private void SpawnPipe()
    {
        if (pipeMovespeed < 5) { pipeMovespeed += 0.2f; }
        Invoke("SpawnPipe", 1 + (pipeMovespeed/10));
        Vector3 spawnPos = new Vector3(1.66f, 0, 0);
        Instantiate(pipe, spawnPos, transform.rotation);
    }
}
