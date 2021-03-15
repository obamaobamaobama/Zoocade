using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogPetManager : MonoBehaviour
{

	private void Start()
	{
		InvokeRepeating("CheckWinner", 0.15f, 0.15f);
	}


	public void zTimesUp()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1Score = GameObject.Find("Progress bar container 1").GetComponent<Transform>().localScale.y;
		var p2Score = GameObject.Find("Progress bar container 2").GetComponent<Transform>().localScale.y;

		if (p1Score > p2Score) { TM.zP1Wins(); }
		if (p1Score < p2Score) { TM.zP2Wins(); }
		if (p1Score == p2Score) { TM.zP12Wins(); }
	}


	private void CheckWinner()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1Score = GameObject.Find("Progress bar container 1").GetComponent<Transform>().localScale.y;
		var p2Score = GameObject.Find("Progress bar container 2").GetComponent<Transform>().localScale.y;

		var scoreToWin = 0.99f;
		if (p1Score > scoreToWin && p2Score < scoreToWin) { TM.zP1Wins(); }
		if (p1Score < scoreToWin && p2Score > scoreToWin) { TM.zP2Wins(); }
		if (p1Score > scoreToWin && p2Score > scoreToWin) { TM.zP12Wins(); }
	}
}
