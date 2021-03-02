using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("microgameManagerFlappyBird");
        transform.position = new Vector2(this.transform.position.x, 0.16f * Random.Range(-5, 5));
    }

    public void Update()
    {
        if (transform.position.x < -2)
        {
            Destroy(transform.gameObject);
        }

        transform.position = transform.position - new Vector3(gameManager.GetComponent<microgameManagerFlappyBird>().pipeMovespeed * Time.deltaTime, 0);
    }
}
