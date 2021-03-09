using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Transform bullet;
    public string tagToIgnore;
    
    void FixedUpdate()
    {
        transform.position = transform.position += new Vector3(0,speed * Time.deltaTime,0);
    }
     private void OnTriggerEnter2D(Collider2D collision)
     {
          if (collision.gameObject.tag == tagToIgnore)
      {
          Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
      else
      {
          Destroy(gameObject);
      }

      
         
     }
}
