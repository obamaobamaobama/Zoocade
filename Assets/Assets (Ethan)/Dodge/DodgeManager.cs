using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeManager : MonoBehaviour
{
	public GameObject p1;
	public GameObject p2;

	[HideInInspector] public bool p1dead = false;
	[HideInInspector] public bool p2dead = false;



	private void Start()
	{
		InvokeRepeating("CheckPlayersDead", 0.25f, 0.25f);
	}


	private void CheckPlayersDead()
	{
		p1dead = p1.GetComponent<DodgePlayers>().dead;
		p2dead = p2.GetComponent<DodgePlayers>().dead;

		if (!p1dead && p2dead) { GameOver(1); }
		if (p1dead && !p2dead) { GameOver(2); }
		if (p1dead && p2dead) { GameOver(12); }
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
			//p1.GetComponent<DodgePlayers>().Dead();
			//p2.GetComponent<DodgePlayers>().Lost();
		}

		if (_playerWhoWon == 2)
		{
			TM.zP2Wins();
			//p1.GetComponent<DodgePlayers>().Lost();
			//p2.GetComponent<DodgePlayers>().Dead();
		}

		if (_playerWhoWon == 12)
		{
			TM.zP12Wins();
			//p1.GetComponent<DodgePlayers>().Won();
			//p2.GetComponent<DodgePlayers>().Won();
		}
	}
}
