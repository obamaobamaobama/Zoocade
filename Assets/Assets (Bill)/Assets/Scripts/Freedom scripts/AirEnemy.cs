using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
    public float speed;
    public bool goRight;
    void Awake()
    {
        if(transform.position.x < 0)
        {
            goRight = true;
        }
        else
        {
            goRight = false;
        }
    }
    void FixedUpdate()
    {
        if(goRight)
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
        }
    }  
    void Update()
    {
        if(transform.position.x == 7 || transform.position.x == -7)
        {
            Destroy(gameObject);
        }
    }
}
