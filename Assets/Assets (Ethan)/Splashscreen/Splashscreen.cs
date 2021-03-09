using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splashscreen : MonoBehaviour
{
    public Object mainMenu;

	private void Start()
	{
		if (mainMenu != null)
		{
			SceneManager.LoadSceneAsync(mainMenu.name);
		}
		else
		{
			Debug.LogWarning("ERROR!: No Main Menu scene in inspector?");
		}
	}
}
