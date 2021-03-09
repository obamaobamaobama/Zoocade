using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TimeManager : MonoBehaviour
{
	[Header("Level Timer (Make sure it's between 5 and 30 seconds)")]
	[SerializeField] private int timer;
    private TextMeshProUGUI textMeshPro;

	public UnityEvent TimesUp;


	public bool player1ready = false;
	public bool player2ready = false;


	public bool player1done = false;
	public bool player2done = false;



	private void Start()
	{
		if (GameObject.Find("TimeManagerText") != null)
		{
			GameObject.Find("TimeManagerText").SetActive(true);
			textMeshPro = GameObject.Find("TimeManagerText").GetComponent<TextMeshProUGUI>();
			InvokeRepeating("TimerCountdown", 1f, 1f);
			ConvertTimeToBitmapGlyphs();
		}
		else
		{
			Debug.LogWarning("ERROR!: No TimeManagerText in scene?");
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
	}
}
