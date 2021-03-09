using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StrengthText : MonoBehaviour
{
	public TextMeshProUGUI textMeshPro;
	private GameObject parentt;

	private float scoreee;


	private void Start()
	{
		parentt = this.gameObject;
	}

	private void Update()
	{
		scoreee = parentt.GetComponent<bellMeter>().score;

		var text = Mathf.Round(scoreee).ToString();


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
		/*.Replace(":", "<sprite index=10>")
		//.Replace("11", "<sprite index=11>")
		.Replace("<", "<sprite index=12>")
		.Replace("=", "<sprite index=13>")
		.Replace(">", "<sprite index=14>")
		.Replace("?", "<sprite index=15>")
		.Replace(" ", "<sprite index=16>")
		//.Replace("", "<sprite index=17>")
		//.Replace("", "<sprite index=18>")
		.Replace("#", "<sprite index=19>")
		.Replace("$", "<sprite index=20>")
		.Replace("%", "<sprite index=21>")
		.Replace("&", "<sprite index=22>")
		//.Replace("", "<sprite index=23>")
		.Replace("(", "<sprite index=24>")
		.Replace(")", "<sprite index=25>")
		.Replace("*", "<sprite index=26>")
		.Replace("+", "<sprite index=27>")
		.Replace(".", "<sprite index=28>")
		.Replace("-", "<sprite index=29>");*/



		textMeshPro.text = text;
	}
}
