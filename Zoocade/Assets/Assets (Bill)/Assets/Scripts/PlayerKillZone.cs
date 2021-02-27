using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillZone : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.tag=="Player")
        {
            Destroy(collision.gameObject);
            Debug.Log(collision.gameObject.name + " has fallen to thier death");
        }
     }
}
