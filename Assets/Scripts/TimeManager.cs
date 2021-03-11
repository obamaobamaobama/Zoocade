using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
	[Header("Level Timer (Make sure it's between 5 and 30 seconds)")]
	[SerializeField] private int timer;

	[Header("1 for up/down, 2 for left/right")]
	[SerializeField] private int playersOrientation;

	private TextMeshProUGUI textMeshPro;
    private TextMeshProUGUI textMeshPro2;
    private TextMeshProUGUI textMeshPro3;
    private TextMeshProUGUI textMeshPro4;

	public UnityEvent TimesUp;


	public bool player1ready = false;
	public bool player2ready = false;


	public bool player1done = false;
	public bool player2done = false;


	private GameObject tmp1;
	private GameObject tmp2;

	private GameObject tmp1tick;
	private GameObject tmp2tick;


	private GameObject readyUpCanvas;

	private GameObject game;


	private GameObject TMc;

	private AudioSource audioo;

	private GameObject p1wl;
	private GameObject p1wlt;
	private GameObject p1wlc;
	private GameObject p2wl;
	private GameObject p2wlt;
	private GameObject p2wlc;

	//0 tie, 1 is p1, 2 is p2;
	private int whoWon;

	private GameObject fadeOut;

	public AudioClip levelLoadReverse;


    private void Awake()
    {
		fadeOut = GameObject.Find("BGFadeOut");
		fadeOut.SetActive(false);

		p1wl = GameObject.Find("_P1_WL_");
		p1wlt = GameObject.Find("_P1_WL_Tick");
		p1wlc = GameObject.Find("_P1_WL_Cross");
		p1wl.SetActive(false);

		p2wl = GameObject.Find("_P2_WL_");
		p2wlt = GameObject.Find("_P2_WL_Tick");
		p2wlc = GameObject.Find("_P2_WL_Cross");
		p2wl.SetActive(false);


		game = GameObject.Find("GAME_");
		game.SetActive(false);

		TMc = GameObject.Find("TimeManagerCanvas");
		TMc.SetActive(false);

		audioo = this.GetComponent<AudioSource>();
	}

    private void Start()
	{
		tmp1 = GameObject.Find("TM_P1_");
		tmp2 = GameObject.Find("TM_P2_");

		tmp1tick = GameObject.Find("TM_P1_Tick_");
		tmp2tick = GameObject.Find("TM_P2_Tick_");

		readyUpCanvas = GameObject.Find("ReadyUpCanvas");


		if (playersOrientation == 1)
		{
			tmp1.transform.position = new Vector2(128, 128);
			tmp1tick.transform.position = new Vector2(128, 192);
			tmp2.transform.position = new Vector2(128, 0);
			tmp2tick.transform.position = new Vector2(128, 64);
		}

		if (playersOrientation == 2)
		{
			tmp1.transform.position = new Vector2(64, 64);
			tmp1tick.transform.position = new Vector2(64, 128);
			tmp2.transform.position = new Vector2(192, 64);
			tmp2tick.transform.position = new Vector2(192, 128);
		}
	}


	private void TimerCountdown()
	{
		if (timer > 0)
		{
			timer -= 1;
			ConvertTimeToBitmapGlyphs();
		}
		else
		{
			//game over
			ConvertTimeToBitmapGlyphs();
			TimesUp.Invoke();
			CancelInvoke("TimerCountdown");
			Debug.Log("Time's Up!");
		}
	}


	private void ConvertTimeToBitmapGlyphs()
	{

		var text = timer.ToString();

		//Replaces text with bitmap glyphs
		text = text
		.Replace("0", "<sprite index=0>")
		.Replace("1", "<sprite index=1>")
		.Replace("2", "<sprite index=2>")
		.Replace("3", "<sprite index=3>")
		.Replace("4", "<sprite index=4>")
		.Replace("5", "<sprite index=5>")
		.Replace("6", "<sprite index=6>")
		.Replace("7", "<sprite index=7>")
		.Replace("8", "<sprite index=8>")
		.Replace("9", "<sprite index=9>");

		textMeshPro.text = text;
		textMeshPro2.text = text;
		textMeshPro3.text = text;
		textMeshPro4.text = text;
	}


	public void zP1Ready()
    {
		player1ready = true;
		tmp1.SetActive(false);
		audioo.Play();
		tmp1tick.GetComponent<Image>().enabled = true;
		tmp1tick.GetComponent<Animator>().enabled = true;
		zCheckIfPlayersAreReady();
	}

	public void zP2Ready()
	{
		player2ready = true;
		tmp2.SetActive(false);
		audioo.Play();
		tmp2tick.GetComponent<Image>().enabled = true;
		tmp2tick.GetComponent<Animator>().enabled = true;
		zCheckIfPlayersAreReady();
	}

	public void zP1Done()
	{
		player1done = true;
		PlayersDoneStopTimer();
	}

	public void zP2Done()
	{
		player2done = true;
		PlayersDoneStopTimer();
	}

	private void PlayersDoneStopTimer()
    {
		if (player1done && player2done)
		{
			TimesUp.Invoke();
			CancelInvoke("TimerCountdown");		}
	}

	private void GiveWinnerLoserIcons()
	{
		p1wl.SetActive(true);
		p2wl.SetActive(true);


		if (whoWon == 0)
		{
			p1wlt.SetActive(true);
			p1wlc.SetActive(false);

			p2wlt.SetActive(true);
			p2wlc.SetActive(false);
		}

		if (whoWon == 1)
		{
			p1wlt.SetActive(true);
			p1wlc.SetActive(false);

			p2wlt.SetActive(false);
			p2wlc.SetActive(true);
		}

		if (whoWon == 2)
		{
			p1wlt.SetActive(false);
			p1wlc.SetActive(true);

			p2wlt.SetActive(true);
			p2wlc.SetActive(false);
		}

		Invoke("StartFade", 1f);
	}

	private void StartFade()
	{
		fadeOut.SetActive(true);
		audioo.clip = levelLoadReverse;
		audioo.Play();
		InvokeRepeating("Fade", 0.008f, 0.008f);
		Invoke("ReloadToMenu", 1f);
	}

	private void Fade()
	{
		fadeOut.GetComponent<RectTransform>().localScale += new Vector3(0.01f, 0.01f);
	}

	private void ReloadToMenu()
	{
		SceneManager.LoadSceneAsync("MainMenu");
	}


	public void zP12Wins()
	{
		whoWon = 0;
		GiveWinnerLoserIcons();
	}

	public void zP1Wins()
	{
		whoWon = 1;
		GiveWinnerLoserIcons();
	}

	public void zP2Wins()
	{
		whoWon = 2;
		GiveWinnerLoserIcons();
	}


	public void zCheckIfPlayersAreReady()
    {
		if (tmp1tick.GetComponent<Animator>().enabled == true && tmp2tick.GetComponent<Animator>().enabled == true)
        {
			Invoke("zCheckIfPlayersAreReady_", 0.5f);
		}
	}

	public void zCheckIfPlayersAreReady_()
    {
		if (tmp1tick.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Idle") && tmp2tick.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
		{
			game.SetActive(true);
			readyUpCanvas.SetActive(false);
			TMc.SetActive(true);
			FindTimeManagerText();
		}
	}

	private void FindTimeManagerText()
	{
		if (GameObject.Find("TimeManagerText") != null)
		{
			GameObject.Find("TimeManagerText").SetActive(true);
			textMeshPro = GameObject.Find("TimeManagerText").GetComponent<TextMeshProUGUI>();
			textMeshPro2 = GameObject.Find("TimeManagerText2").GetComponent<TextMeshProUGUI>();
			textMeshPro3 = GameObject.Find("TimeManagerText3").GetComponent<TextMeshProUGUI>();
			textMeshPro4 = GameObject.Find("TimeManagerText4").GetComponent<TextMeshProUGUI>();
			InvokeRepeating("TimerCountdown", 1f, 1f);
			ConvertTimeToBitmapGlyphs();
		}
		else
		{
			Debug.LogWarning("ERROR!: No TimeManagerText in scene?");
		}
	}
}