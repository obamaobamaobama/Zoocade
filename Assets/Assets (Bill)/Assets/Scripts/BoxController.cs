using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public float maxX;
    public float minX;
    public bool leftBorder;
    public bool freeze = true;
    public float speed;
    public Rigidbody2D rb;
    void Awake()
    {
        Debug.Log("Awake");
        int x = Random.Range(0,2); //0 to 1
        Debug.Log(x);
        freeze = true;
        if(x == 0)
        {
            leftBorder = true;
        }
        else
        {
             leftBorder = false;
        }
    }
    void Update()
    {
        if(freeze)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePositionY;
        }
        checkBorder();
        
    }
    public void FixedUpdate()
    {
        if(leftBorder)
        {
            zMoveRight();
        }
       else
        {
            zMoveLeft();
        }
    }
    public void zUnfreeze()
    {
        freeze = false;
         rb.WakeUp();
    }
    public void zMoveLeft()
    {
        if(transform.position.x > minX && freeze)
        transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
    }

    public void zMoveRight()
    {
        if (transform.position.x < maxX && freeze)
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
    }
    public void checkBorder()
    {
        if(transform.position.x < minX + 0.1f && freeze)
        {
            leftBorder =true;
        }
        if(transform.position.x > maxX - 0.1f && freeze)
        {
            leftBorder =false;
        }
    }
}

