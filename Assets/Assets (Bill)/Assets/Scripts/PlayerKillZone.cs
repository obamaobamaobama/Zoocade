using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillZone : MonoBehaviour
{
    public GameObject pointer1;
    public GameObject pointer2;
     private void OnTriggerEnter2D(Collider2D collision)
     {
         if(collision.tag=="Player")
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody2D>());
            Debug.Log(collision.gameObject.name + " has fallen to thier death");
        }
        if(collision.gameObject.name == "player 1")
        {
            Destroy(pointer1);
        }
        if(collision.gameObject.name == "player 2")
        {
            Destroy(pointer2);
        }
     }
}
