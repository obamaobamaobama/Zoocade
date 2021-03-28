using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public Animator ani;
    public GameObject enemy;
    public Collider2D col;
    public Rigidbody2D rb;
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "minus")
        {
            Destroy(other.gameObject);
           bool ae = enemy.TryGetComponent<AirEnemy>(out var air);
            if(ae)
            {
                air.SetDestroyed();
                 col.enabled = false;
            }
            bool ge = enemy.TryGetComponent<GroundEnemy>(out var ground);
            if(ge)
            {
                ground.SetDestroyed();
                 col.enabled = false;
            }
            ani.Play("Player explode");
            rb.constraints = RigidbodyConstraints2D.FreezePositionY;
            col.enabled = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(gameObject.tag =="Bomb" && other.gameObject.tag == "Player")
        {
             ani.Play("Player explode");
             rb.constraints = RigidbodyConstraints2D.FreezePositionY;
             col.enabled = false;
        }
        
    }
}
