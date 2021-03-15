using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Splashscreen : MonoBehaviour
{
    public Object mainMenu;

	private void Start()
	{
		/*if (mainMenu != null)
		{
			//SceneManager.LoadSceneAsync(mainMenu.name);
			//SceneManager.LoadSceneAsync("MainMenu");
			//SceneManager.LoadScene("MainMenu");
			SceneManager.LoadScene(1);
		}
		else
		{
			Debug.LogWarning("ERROR!: No Main Menu scene in inspector?");
		}*/

		// Loads Main Menu
		SceneManager.LoadScene(1);
	}
}