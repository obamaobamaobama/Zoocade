using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomGameSelect : MonoBehaviour
{
	private GameObject backgroundFade;

    public Sprite[] sprites;
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
		this.GetComponent<Image>().sprite = sprites[Random.Range(0, sprites.Length)];

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
		// Load selected level

		// For now, just load strength test
		SceneManager.LoadSceneAsync("Strength Test");
	}


	private void Fade()
	{
		backgroundFade.GetComponent<RectTransform>().localScale += new Vector3(0.01f, 0.01f);
	}
}
