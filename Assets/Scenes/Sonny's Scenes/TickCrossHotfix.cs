using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickCrossHotfix : MonoBehaviour
{
    public GameObject follow;

    private void Update()
    {
        if (follow != null)
        {
            transform.position = follow.GetComponent<Transform>().position;
        }
    }
}
