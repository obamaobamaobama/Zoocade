using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBlock : MonoBehaviour
{
    private float speed = 2;

    // true if left, false if right
    [HideInInspector] public bool leftBlock;


    void Update()
    {
        transform.position -= new Vector3(0, speed) * Time.deltaTime;

        if (transform.position.y < -5.6f)
		{
            Destroy(this.gameObject);
		}
    }
}
