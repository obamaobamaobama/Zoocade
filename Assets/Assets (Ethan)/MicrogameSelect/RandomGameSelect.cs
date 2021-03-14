using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomGameSelect : MonoBehaviour
{
	private GameObject backgroundFade;

    public Sprite[] sprites;
    public Object[] microGames;
	public float randomSpeed;
	private AudioSource audioo;
	private bool booya = false;

	public AudioClip levelLoadedSound;


	private void Awake()
	{
		backgroundFade = GameObject.Find("BGFadeOut");
		backgroundFade.SetActive(false);
	}


	private void Start()
	{
		audioo = this.GetComponent<AudioSource>();

		randomSpeed = 0.01f;
		CycleThroughGames();
	}

	private void CycleThroughGames()
	{
		audioo.Play();
		//this.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];


		// Change this to
		//this.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
		// when all games are added
		//int[] numbers = { 11-1, 12-1, 13-1, 14-1, 21-1, 22-1, 25-1 };
		int[] numbers = { 21-1, 22-1, 25-1 };
		int randomIndex = Random.Range(0, numbers.Length);
		int randomIntFromNumbers = numbers[randomIndex];
		this.GetComponent<Image>().sprite = sprites[randomIntFromNumbers];
		// yeet



		if (randomSpeed < 0.18f)
		{
			randomSpeed += (randomSpeed/10);
			Invoke("CycleThroughGames", randomSpeed);
		}
		else
		{
			if (!booya)
			{
				Invoke("BooyaBaby", randomSpeed);
			}
		}
	}


	private void BooyaBaby()
	{
		//this.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];
		booya = true;

		// PLAY COOL SOUNDS
		audioo.clip = levelLoadedSound;
		audioo.Play();

		// LOAD MICROGAME AFTER DELAY
		Invoke("BooyaBaby2", 1f);
		backgroundFade.SetActive(true);
		InvokeRepeating("Fade", 0.008f, 0.008f);
	}


	private void BooyaBaby2()
	{
		// Use ARRAY for this later, once all levels are done
		// Load selected level


		//if (this.GetComponent<Image>().sprite == sprites[1-1]) { SceneManager.LoadSceneAsync("Surfing Fish"); }
		//if (this.GetComponent<Image>().sprite == sprites[2-1]) { SceneManager.LoadSceneAsync("Frog Meditation"); }
		//if (this.GetComponent<Image>().sprite == sprites[3-1]) { SceneManager.LoadSceneAsync("Flea Circus"); }
		//if (this.GetComponent<Image>().sprite == sprites[4-1]) { SceneManager.LoadSceneAsync("Roo Boxing"); }
		//if (this.GetComponent<Image>().sprite == sprites[5-1]) { SceneManager.LoadSceneAsync("Human Racing"); }

		//if (this.GetComponent<Image>().sprite == sprites[6-1]) { SceneManager.LoadSceneAsync("Plenty of Fish"); }
		//if (this.GetComponent<Image>().sprite == sprites[7-1]) { SceneManager.LoadSceneAsync("Guard Dog"); }
		//if (this.GetComponent<Image>().sprite == sprites[8-1]) { SceneManager.LoadSceneAsync("Parrot-chute"); }
		//if (this.GetComponent<Image>().sprite == sprites[9-1]) { SceneManager.LoadSceneAsync("Metamorphis"); }
		//if (this.GetComponent<Image>().sprite == sprites[10-1]) { SceneManager.LoadSceneAsync("Sheep Barber"); }

		if (this.GetComponent<Image>().sprite == sprites[11-1]) { SceneManager.LoadSceneAsync("Aesteroid"); }
		if (this.GetComponent<Image>().sprite == sprites[12-1]) { SceneManager.LoadSceneAsync("Basket"); }
		if (this.GetComponent<Image>().sprite == sprites[13-1]) { SceneManager.LoadSceneAsync("Tower"); }
		if (this.GetComponent<Image>().sprite == sprites[14-1]) { SceneManager.LoadSceneAsync("Snail"); }
		//if (this.GetComponent<Image>().sprite == sprites[15-1]) { SceneManager.LoadSceneAsync("2 ball pong"); }

		//if (this.GetComponent<Image>().sprite == sprites[16-1]) { SceneManager.LoadSceneAsync("Bill 6"); }
		//if (this.GetComponent<Image>().sprite == sprites[17-1]) { SceneManager.LoadSceneAsync("Bill 7"); }
		//if (this.GetComponent<Image>().sprite == sprites[18-1]) { SceneManager.LoadSceneAsync("Bill 8"); }
		//if (this.GetComponent<Image>().sprite == sprites[19-1]) { SceneManager.LoadSceneAsync("Bill 9"); }
		//if (this.GetComponent<Image>().sprite == sprites[20-1]) { SceneManager.LoadSceneAsync("Bill 10"); }

		if (this.GetComponent<Image>().sprite == sprites[21-1]) { SceneManager.LoadSceneAsync("21. Flappy Bird"); }
		if (this.GetComponent<Image>().sprite == sprites[22-1]) { SceneManager.LoadSceneAsync("22. Reflex"); }
		//if (this.GetComponent<Image>().sprite == sprites[23-1]) { SceneManager.LoadSceneAsync("Dance Battle"); }
		//if (this.GetComponent<Image>().sprite == sprites[24-1]) { SceneManager.LoadSceneAsync("Dodge"); }
		if (this.GetComponent<Image>().sprite == sprites[25-1]) { SceneManager.LoadSceneAsync("25. Strength Test"); }

		//if (this.GetComponent<Image>().sprite == sprites[26-1]) { SceneManager.LoadSceneAsync("Ethan 6"); }
		//if (this.GetComponent<Image>().sprite == sprites[27-1]) { SceneManager.LoadSceneAsync("Ethan 7"); }
		//if (this.GetComponent<Image>().sprite == sprites[28-1]) { SceneManager.LoadSceneAsync("Ethan 8"); }
		//if (this.GetComponent<Image>().sprite == sprites[29-1]) { SceneManager.LoadSceneAsync("Ethan 9"); }
		//if (this.GetComponent<Image>().sprite == sprites[30-1]) { SceneManager.LoadSceneAsync("Ethan 10"); }
	}


	private void Fade()
	{
		backgroundFade.GetComponent<RectTransform>().localScale += new Vector3(0.01f, 0.01f);
	}
}
