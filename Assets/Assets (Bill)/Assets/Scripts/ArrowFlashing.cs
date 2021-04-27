using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFlashing : MonoBehaviour
{
    public SpriteRenderer arrow;
    public float timeToShow = 0.2f;
    public float timeToStop = 1;

     void Awake()
    {
        arrow.enabled = false;
    }
       void FixedUpdate()
    {
        if(Time.time > timeToShow)
        {
            arrow.enabled = true;
        }
        if(Time.time > timeToStop)
        {
            arrow.enabled = false;
        }
    }

   
}
