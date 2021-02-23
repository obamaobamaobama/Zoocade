using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{

    private void Start()
    {
        transform.position = new Vector2(this.transform.position.x, 0.16f * Random.Range(-5, 5));
    }

    public void Update()
    {
        transform.position = transform.position - new Vector3(1 * Time.deltaTime, 0);
    }
}
