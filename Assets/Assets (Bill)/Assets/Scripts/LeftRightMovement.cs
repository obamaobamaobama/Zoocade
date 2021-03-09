using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftRightMovement : MonoBehaviour
{
    public float speed;
    public float xlimit;
    public Text display;
    public string p1orp2;
    void zMoveLeft()
    {
        if(transform.position.x > -xlimit)
        transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
    }

    void zMoveRight()
    {
        if (transform.position.x < xlimit)
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
    }
    void FixedUpdate()
    {
        if (transform.position.x >= 3)
        {
            display.text = p1orp2 + "Wins"; //*E put in the win script here
        }
    }
}
