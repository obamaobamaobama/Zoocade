using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public bool grounded;
    public Transform player;
    public Rigidbody2D rb;
    [SerializeField]
    float velocity;
        public void zMoveLeft()
    {
        if(Mathf.Round(transform.position.x) > -5)
        {
            transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
        }
        
    }

    public void zMoveRight()
    {
        if (Mathf.Round(transform.position.x) < 5)
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
        }
       
        
    }
    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce);
        grounded = false;
    }
    public void FixedUpdate()
    {
        if(grounded && velocity == 0f)
        {
            Jump();
        }
        velocity = rb.velocity.y;
    }
   void OnTriggerEnter2D(Collider2D col)
   {
       if (col.gameObject.tag == "ground")
      {
          grounded = true;
      }
   }
   void OnTriggerExit2D(Collider2D col)
   { 
     grounded = false;
   }
}
