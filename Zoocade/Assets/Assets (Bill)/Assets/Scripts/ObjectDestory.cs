using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestory : MonoBehaviour
{
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
        
    }
}
