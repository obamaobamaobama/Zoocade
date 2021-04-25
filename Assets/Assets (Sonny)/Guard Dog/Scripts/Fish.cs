using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A simple script for calling the destruction of the fish game object upon collision with the Player

public class Fish : MonoBehaviour
{
    public Collider2D fishTriggerZone;

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }


    }
}
