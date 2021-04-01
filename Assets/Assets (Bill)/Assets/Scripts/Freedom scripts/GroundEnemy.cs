using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : MonoBehaviour
{
    public float speed;
    public bool destroyed = false;
    public SpriteRenderer body;
    public bool goTowardsMiddle;
    public bool checkNeedToFlip;
    public bool explosive = false;
    public Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        if (checkNeedToFlip)
        {
            if(transform.position.x < 0)
             {
            body.flipX = false;
            }
            if(transform.position.x > 0)
            {
            body.flipX = true;
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(destroyed == false && goTowardsMiddle)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector3(0,transform.position.y,0), speed * Time.deltaTime);
        }
        if(!goTowardsMiddle) //go towards left
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0);
        }
    }
    void Update()
    {
       if(transform.position.x == 0 && goTowardsMiddle) 
       {
           Destroy(gameObject);
       }
    }
     public void SetDestroyed()
    {
        destroyed = true;
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && explosive)
        {
            SetDestroyed();
            ani.Play("Player explode");
        }
    }
}
