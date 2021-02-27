using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour
{
    public float bouniciness;
    void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.relativeVelocity.y <=0f) //idk what relativevelocity means, but it make sure it only happens after player landed
       {
         Rigidbody2D rb= collision.collider.GetComponent<Rigidbody2D>();
            if(rb !=null)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = bouniciness;
            rb.velocity = velocity;
        }
       }
    }
}
