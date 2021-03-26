using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
   public int hp = 5;
   public SpriteRenderer[] hearts;
   void OnTriggerEnter2D(Collider2D other)
   {
       if(other.gameObject.tag == "Enemy")
       {
           hp--;
           Destroy(other.gameObject);
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
}
