using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    public float thrustForce;
    public float moveSpeed;
    public Rigidbody2D rb;
    
    void LateUpdate()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position); //
        pos.x = Mathf.Clamp01(pos.x);                                       // all of this keep player inside camera bounds
        transform.position = Camera.main.ViewportToWorldPoint(pos);         //
    }
    public void zThrust()
    {
        rb.AddForce(Vector2.up * thrustForce * Time.deltaTime);
    }
    public void zMoveLeft()
    {
        transform.position = transform.position + new Vector3(-moveSpeed * Time.fixedDeltaTime, 0);
    }
    public void zMoveRight()
    {
         transform.position = transform.position + new Vector3(moveSpeed * Time.fixedDeltaTime, 0);
    }
}
