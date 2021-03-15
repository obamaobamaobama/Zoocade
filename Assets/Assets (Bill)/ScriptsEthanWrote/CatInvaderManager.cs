using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatInvaderManager : MonoBehaviour
{
	private GameObject P1;
	private GameObject P2;
	private bool timesUp = false;


	private void Start()
	{
		InvokeRepeating("CheckPlayersAlive", 0.5f, 0.5f);
	}

	private void CheckPlayersAlive()
	{
		if (!timesUp)
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

			if (GameObject.Find("Player 1") != null) { P1 = GameObject.Find("Player 1"); }
			if (GameObject.Find("Player 2") != null) { P2 = GameObject.Find("Player 2"); }

			if (P1 != null && P2 == null) { TM.zP1Wins(); }
			if (P1 == null && P2 != null) { TM.zP2Wins(); }
		}
	}

	public void zTimesUp()
	{
		timesUp = true;

		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1Score = GameObject.Find("PointCalc").GetComponent<pointCalc>().zP1Score;
		var p2Score = GameObject.Find("PointCalc").GetComponent<pointCalc>().zP2Score;

		if (p1Score > p2Score) { TM.zP1Wins(); }
		if (p1Score < p2Score) { TM.zP2Wins(); }
		if (p1Score == p2Score) { TM.zP12Wins(); }
	}
}
