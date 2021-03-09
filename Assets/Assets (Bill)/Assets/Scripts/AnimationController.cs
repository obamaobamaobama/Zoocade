using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator p1button;
    public Animator p2button;
    public Animator p1heart;
    public Animator p2heart;
    static bool pause;
    void Update()
    {
        if (pause)
        {
            p1button.enabled = false;
            p2button.enabled = false;
            p1heart.enabled = false;
            p2heart.enabled = false;
        }

    }
}
