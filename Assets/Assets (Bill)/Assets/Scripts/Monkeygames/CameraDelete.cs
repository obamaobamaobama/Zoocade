using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDelete : MonoBehaviour
{
    public GameObject cameraYeet;

    private void Start()
    {
        Destroy(cameraYeet);
    }
}
