using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float speed;
    private Animator ani;

    // Ethan wrote this
    public float boundaryLimit = 5.5f;

        public void zMoveLeft()
    {
        if(transform.position.x > -boundaryLimit)
        {
            transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
        }
        
    }

    public void zMoveRight()
    {
        if (transform.position.x < boundaryLimit)
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
        if (transform.position.x > (boundaryLimit-.1f)) //if at right border, go to left border
        {
            transform.position = new Vector3((-boundaryLimit+.2f),transform.position.y,0);
        }
        if (transform.position.x < -boundaryLimit+.1f) //if at left border, go to right border
        {
            transform.position = new Vector3(boundaryLimit-.2f, transform.position.y,0);
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
