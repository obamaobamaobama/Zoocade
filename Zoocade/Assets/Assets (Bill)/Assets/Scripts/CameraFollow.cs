using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform target2;
    

    // Update is called once per frame
    void LateUpdate() // camera moves slightly behind player so no jittering
    {
        if(target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target.position.y, transform.position.z);
             transform.position = newPos;
        }
         if(target2.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, target2.position.y, transform.position.z);
             transform.position = newPos;
        }
    }
}
