using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirEnemy : MonoBehaviour
{
    public float speed;
    public bool goRight;
    public GameObject bomb;
    public bool dropped = false;
    public bool destroyed = false;
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
        if (destroyed == false)
        {
            if(goRight)
            {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
            }
            else
            {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
             }

            if(transform.position.x <= 0.2&& transform.position.x >=-0.2)
            {
                if(dropped == false)
                {
                    Instantiate(bomb, new Vector3(transform.position.x, transform.position.y - 0.5f, 0), transform.rotation);
                    dropped = true;
                }
            }
        }
    }  
    void Update()
    {
        if(transform.position.x == 7 || transform.position.x == -7)
        {
            Destroy(gameObject);
        }
    }
    public void SetDestroyed()
    {
        destroyed = true;
    }
}
