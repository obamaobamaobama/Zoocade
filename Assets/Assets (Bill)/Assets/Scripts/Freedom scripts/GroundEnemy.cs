using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float speed;
      public bool destroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(destroyed == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(0,transform.position.y,0), speed * Time.deltaTime);
        }
    }
    void Update()
    {
       if(transform.position.x == 0) 
       {
           Destroy(gameObject);
       }
    }
     public void SetDestroyed()
    {
        destroyed = true;
    }
}
