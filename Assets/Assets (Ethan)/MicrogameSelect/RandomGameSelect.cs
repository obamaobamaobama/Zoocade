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
		int[] numbers = { 5-1, 6-1, 7-1, 8-1, 11-1, 12-1, 13-1, 14-1, 15-1, 16-1, 17-1, 18-1, 19-1, 20-1, 21-1, 22-1, 23-1, 24-1, 25-1, 26-1, 27-1};
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
		// 04. Roo Boxing (Cancelled)
		//if (this.GetComponent<Image>().sprite == sprites[4 - 1]) { SceneManager.LoadScene(22); }
		// 05. Human Racing
		if (this.GetComponent<Image>().sprite == sprites[5 - 1]) { SceneManager.LoadScene(23); }


		// 06. Sheep Barber
		if (this.GetComponent<Image>().sprite == sprites[6 - 1]) { SceneManager.LoadScene(19); }
		// 07. Guard Dog
		if (this.GetComponent<Image>().sprite == sprites[7 - 1]) { SceneManager.LoadScene(20); }
		// 08. Frog Meditation
		if (this.GetComponent<Image>().sprite == sprites[8 - 1]) { SceneManager.LoadScene(21); }
		// 09 Cancelled
		// 10 Cancelled


		// 11. Aesteroid
		if (this.GetComponent<Image>().sprite == sprites[11-1]) { SceneManager.LoadScene(6); }
		// 12. Basket
		if (this.GetComponent<Image>().sprite == sprites[12-1]) { SceneManager.LoadScene(7); }
		// 13. Tower
		if (this.GetComponent<Image>().sprite == sprites[13-1]) { SceneManager.LoadScene(12); }
		// 14. Snail
		if (this.GetComponent<Image>().sprite == sprites[14-1]) { SceneManager.LoadScene(11); }
		// 15. Cat Invader
		if (this.GetComponent<Image>().sprite == sprites[15-1]) { SceneManager.LoadScene(8); }


		// 16. Dog Petting
		if (this.GetComponent<Image>().sprite == sprites[16-1]) { SceneManager.LoadScene(9); }
		// 17. Frog Jump
		if (this.GetComponent<Image>().sprite == sprites[17-1]) { SceneManager.LoadScene(10); }
		// 18. Trivia
		if (this.GetComponent<Image>().sprite == sprites[18-1]) { SceneManager.LoadScene(13); }
		// 19. Freedom
		if (this.GetComponent<Image>().sprite == sprites[19 - 1]) { SceneManager.LoadScene(15); }
		// 20. Jetpack
		if (this.GetComponent<Image>().sprite == sprites[20 - 1]) { SceneManager.LoadScene(16); }


		// 21. Flappy Bird
		if (this.GetComponent<Image>().sprite == sprites[21-1]) { SceneManager.LoadScene(5); }
		// 22. Reflex
		if (this.GetComponent<Image>().sprite == sprites[22-1]) { SceneManager.LoadScene(14); }
		// 23. Dance Battle
		if (this.GetComponent<Image>().sprite == sprites[23 - 1]) { SceneManager.LoadScene(24); }
		// 24. Dodge
		if (this.GetComponent<Image>().sprite == sprites[23 - 1]) { SceneManager.LoadScene(25); }
		// 25. Strength Test
		if (this.GetComponent<Image>().sprite == sprites[25-1]) { SceneManager.LoadScene(4); }


		// 26. Jetpack 2
		if (this.GetComponent<Image>().sprite == sprites[26 - 1]) { SceneManager.LoadScene(17); }
		// 27. Monkey Dodge
		if (this.GetComponent<Image>().sprite == sprites[27 - 1]) { SceneManager.LoadScene(18); }
		// 28 Cancelled
		// 29 Cancelled
		// 30 Cancelled
	}


	private void Fade()
	{
		if (backgroundFade.GetComponent<RectTransform>().localScale.x < 1)
		{
			backgroundFade.GetComponent<RectTransform>().localScale += new Vector3(0.01f, 0.01f);
		}
		else
		{
			BooyaBaby2();
		}
	}
}
