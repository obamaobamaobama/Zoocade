using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanRacingManager : MonoBehaviour
{
	[HideInInspector] public bool player1lost = false;
	[HideInInspector] public bool player2lost = false;
	[HideInInspector] public bool gameOver = false;

	public GameObject p1;
	public GameObject p2;


	private void CheckWhoWon()
	{
		if (!player1lost && player2lost) { Invoke("CheckWhoWonYeet", 0.5f); p1.GetComponent<HorsePlayers>().zWin(); p2.GetComponent<HorsePlayers>().zLose(); }
		if (player1lost && !player2lost) { Invoke("CheckWhoWonYeet", 0.5f); p1.GetComponent<HorsePlayers>().zLose(); p2.GetComponent<HorsePlayers>().zWin(); }
		if (player1lost && player2lost) { Invoke("CheckWhoWonYeet", 0.5f); p1.GetComponent<HorsePlayers>().zWin(); p2.GetComponent<HorsePlayers>().zWin(); }
	}


	private void CheckWhoWonYeet()
	{
		if (!player1lost && player2lost) { GameOver(1); }
		if (player1lost && !player2lost) { GameOver(2); }
		if (player1lost && player2lost) { GameOver(12); }
	}


	public void TimesUp()
	{
		GameOver(12);
		p1.GetComponent<HorsePlayers>().zWin();
		p2.GetComponent<HorsePlayers>().zWin();
	}

	private void GameOver(int _playerWhoWon)
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

		if (_playerWhoWon == 1)
		{
			TM.zP1Wins();
		}

		if (_playerWhoWon == 2)
		{
			TM.zP2Wins();
		}

		if (_playerWhoWon == 12)
		{
			TM.zP12Wins();
		}


		gameOver = true;
	}



	private void Update()
	{
		CheckWhoWon();
	}
}
