using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public bool destroyEnmeyOnTrigger = true;
   public int hp = 5;
   public SpriteRenderer[] hearts;
   private Rigidbody2D rb;
    public Animator ani;
   public bool explosive;

   void Start()
   {
       rb = GetComponent<Rigidbody2D>();
   }
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag == "Enemy")
       {
           hp--;
           if(destroyEnmeyOnTrigger)
           {
            Destroy(other.gameObject);
           }
          
       }
       if(other.gameObject.tag == "Bomb")
       {
           hp--;
       }
   }
   void Update()
   {
       for (int i = 0; i < hearts.Length; i++)
       {
           if(i < hp)
           {
               hearts[i].enabled = true;
           }
           else
           {
               hearts[i].enabled = false;
           }
       }
   }
   void FixedUpdate()
   {
       if(hp<= 0 && explosive)
       {
           Destroy(rb);
           ani.Play("Player explode");
       }
       if(hp<= 0 && !explosive)
       {
           Destroy(gameObject);
       }
   }
}
