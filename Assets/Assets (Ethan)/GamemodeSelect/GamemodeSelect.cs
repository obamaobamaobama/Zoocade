using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemodeSelect : MonoBehaviour
{
    public Object freeplay;
    public Object normal;

    public void zFreeplay()
    {
        if (freeplay != null)
        {
            SceneManager.LoadSceneAsync(freeplay.name);
        }
        else
        {
            Debug.LogWarning("ERROR!: No freeplay scene in inspector?");
        }
    }

    public void zNormal()
    {
        if (normal != null)
        {
            SceneManager.LoadSceneAsync(normal.name);
        }
        else
        {
            Debug.LogWarning("ERROR!: No normal scene in inspector?");
        }
    }
}
