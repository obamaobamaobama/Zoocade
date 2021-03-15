using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnailManager : MonoBehaviour
{


	private void Update()
	{
		var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		if (scoreText == "P1Wins")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP1Wins();
		}

		if (scoreText == "P2Wins")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP2Wins();
		}
	}

	public void zTimesUp()
	{
		var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		if (scoreText == "")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP12Wins();
		}
	}
}
