using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunShells : MonoBehaviour
{
    public float force;
    public Rigidbody2D rb;
   void Awake()
   {
    rb.AddForce(-transform.up * force);
    rb.AddForce(Vector2.up * force);
   }
    
}
