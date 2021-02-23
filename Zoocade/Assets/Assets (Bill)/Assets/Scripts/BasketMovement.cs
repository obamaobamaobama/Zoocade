﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{   
    public float speed;
    public float gravity;
    public float vsp;
    public float jumpForce;
    public bool grounded;
    
    
    public Transform player;
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
    public void zABPressed()
    {
        if(grounded)
        {
            vsp = 0;
            vsp += jumpForce;
            grounded = false;
        }
        
    }
    public void Update()
    {
        transform.position += new Vector3(0,vsp);

        if(transform.position.y >-3.5f)
        {
            vsp-=gravity * Time.fixedDeltaTime;
        }
        else
        {
            grounded = true;
            transform.position = new Vector3(transform.position.x,-3.5f);
        }
        
    }
    void OnCollisionEnter2D(Collision2D col)
  {
      if (col.gameObject.tag == "player")
      {
          Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
  }
}
