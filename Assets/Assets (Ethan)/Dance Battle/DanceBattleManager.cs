using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBattleManager : MonoBehaviour
{
    public float danceBlockSpeed = 10;
	[HideInInspector] public bool player1lost = false;
	[HideInInspector] public bool player2lost = false;
	[HideInInspector] public bool gameOver = false;

	public GameObject p1;
	public GameObject p2;


	private void Start()
	{
		//InvokeRepeating("SpeedUp", 1f, 1f);
		InvokeRepeating("CheckWhoWon", 0.25f, 0.25f);
	}

	private void SpeedUp()
	{
		if (danceBlockSpeed < 10) { danceBlockSpeed += 1; } else { CancelInvoke(); }
	}

	private void CheckWhoWon()
	{
		if (!player1lost && player2lost) { GameOver(1); }
		if (player1lost && !player2lost) { GameOver(2); }
		if (player1lost && player2lost)	 { GameOver(12); }
	}


	public void TimesUp()
	{
		GameOver(12);
	}

	private void GameOver(int _playerWhoWon)
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

		if (_playerWhoWon == 1)
		{
			TM.zP1Wins();
			p1.GetComponent<DanceBattlePlayers>().Won();
			p2.GetComponent<DanceBattlePlayers>().Lost();
		}

		if (_playerWhoWon == 2)
		{
			TM.zP2Wins();
			p1.GetComponent<DanceBattlePlayers>().Lost();
			p2.GetComponent<DanceBattlePlayers>().Won();
		}

		if (_playerWhoWon == 12)
		{
			TM.zP12Wins();
			p1.GetComponent<DanceBattlePlayers>().Won();
			p2.GetComponent<DanceBattlePlayers>().Won();
		}


		gameOver = true;
	}
}
