using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
   public float speed;
    
    void LateUpdate()
    {
        transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
    }
}
