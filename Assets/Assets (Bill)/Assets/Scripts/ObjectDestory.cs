using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestory : MonoBehaviour
{
    public bool ableToDestroyEnemies;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="plus")
        {
            Destroy(collision.gameObject);
        }
        if(collision.tag=="minus")
        {
            Destroy(collision.gameObject);
        }
        
        if (ableToDestroyEnemies && collision.tag =="Enemy")
        {
            Destroy(collision.gameObject);
        }
        if (collision.tag =="Bomb")
        {
            Destroy(collision.gameObject);
        }
    }
}
