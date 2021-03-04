using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Object testScene;

    public void zTwoPlayer()
    {
        if (testScene != null)
        {
            SceneManager.LoadSceneAsync(testScene.name);
        }
        else
        {
            Debug.LogWarning("ERROR!: No Test scene in inspector?");
        }
    }
}
