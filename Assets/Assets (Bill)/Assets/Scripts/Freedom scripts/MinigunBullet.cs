using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunBullet : MonoBehaviour
{
    public float speed;
    void FixedUpdate()
    {
        transform.position += transform.up* Time.deltaTime * speed;
    }
}
