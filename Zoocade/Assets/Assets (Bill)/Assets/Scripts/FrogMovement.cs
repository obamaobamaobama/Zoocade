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
    public float restTime;
    public float setRestTime;
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
        if(restTime <= 0)
        {
            rb.AddForce(transform.up * jumpForce);
            grounded = false;
            restTime = setRestTime;
        }
        
    }
    public void FixedUpdate()
    {
        if(grounded && velocity == 0)
        {
            Jump();
            restTime -= Time.fixedDeltaTime;
        }
        else
        {
            restTime = setRestTime;
        }
        velocity = rb.velocity.y;
    }
    void OnCollisionEnter2D(Collision2D col)
  {
      if (col.gameObject.tag == "player")
      {
          Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
  }
   void OnTriggerEnter2D(Collider2D col)
   {
       if (col.gameObject.tag == "ground")
      {
          restTime = setRestTime;
          grounded = true;
      }
   }
   void OnTriggerExit2D(Collider2D col)
   { 
      
     grounded = false;
     restTime = setRestTime;
   }
}
