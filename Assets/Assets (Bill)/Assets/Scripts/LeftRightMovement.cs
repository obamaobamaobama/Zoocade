using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightMovement : MonoBehaviour
{
    public float speed;
    public float xlimit;
    public AudioSource speaker;
    void zMoveLeft()
    {
        if(transform.position.x > -xlimit)
        transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
    }

    void zMoveRight()
    {
        if (transform.position.x < xlimit)
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
            if (speaker!=null)
            {
                speaker.Play();
            }
    }
}
