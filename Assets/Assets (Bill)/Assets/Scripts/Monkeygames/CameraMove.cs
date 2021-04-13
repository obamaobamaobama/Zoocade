using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
   public float speed;

    void Update()
    {
        Vector3 nextPos = transform.position;
        nextPos.x = transform.position.x + (speed * Time.deltaTime);
        transform.position = nextPos;
    }
}
