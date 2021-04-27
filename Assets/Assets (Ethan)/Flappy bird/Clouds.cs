using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    
    void Update()
    {
        if (this.GetComponent<Transform>().position.x > -2.6f)
        {
            this.GetComponent<Transform>().position -= new Vector3(3, 0, 0) * Time.deltaTime;
        }
        else
		{
            this.GetComponent<Transform>().position = new Vector3(2.6f, this.GetComponent<Transform>().position.y);
        }
    }
}
