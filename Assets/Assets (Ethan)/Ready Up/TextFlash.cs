using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    private bool invisible = true;

    private void Start()
    {
        InvokeRepeating("Flash", 0.5f, 0.5f);
    }

    void Flash()
    {
        invisible = !invisible;
        this.GetComponent<Image>().enabled = invisible;
    }
}
