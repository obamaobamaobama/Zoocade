using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float speed;
    private Animator ani;
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
    void Start()
    {
        ani = GetComponent<Animator>();
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
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y >=0f) // checking if the platform collides is from the bottom
        {
            ani.SetBool("AnimatorGrounded",true);
        }
        
    }
    void OnCollisionExit2D()
    {
        ani.SetBool("AnimatorGrounded",false);
    }
}
