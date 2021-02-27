using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float speed;
    
    [SerializeField]
        public void zMoveLeft()
    {
        if(transform.position.x > -6)
        {
            transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
        }
        
    }

    public void zMoveRight()
    {
        if (transform.position.x < 6)
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
        }
    }
    void FixedUpdate()
    {
        Teleport();
    }
    void Teleport()
    {
        if (transform.position.x > 5.5) //if at right border, go to left border
        {
            transform.position = new Vector3(-5.4f,transform.position.y,0);
        }
        if (transform.position.x <-5.5) //if at left border, go to right border
        {
            transform.position = new Vector3(5.4f,transform.position.y,0);
        }
    }
}
