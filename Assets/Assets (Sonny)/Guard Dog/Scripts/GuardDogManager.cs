using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardDogManager : MonoBehaviour
{
	public void zTimesUp()
	{
	var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
	var p1 = GameObject.Find("CatBurglar P1");
	var p2 = GameObject.Find("CatBurglar P2");

	if (p1.GetComponent<CatBurglarPlayers>().GotFish && p2.GetComponent<CatBurglarPlayers>().GotFish)
		{
		// Both players win
		TM.zP12Wins();
		}

		if (!p1.GetComponent<CatBurglarPlayers>().GotFish && !p2.GetComponent<CatBurglarPlayers>().GotFish)
		{
			// Both players lose
			TM.zP12Lose();
		}

		if (p1.GetComponent<CatBurglarPlayers>().GotFish && !p2.GetComponent<CatBurglarPlayers>().GotFish)
		{
			// P1 Wins
			TM.zP1Wins();
		}

		if (!p1.GetComponent<CatBurglarPlayers>().GotFish && p2.GetComponent<CatBurglarPlayers>().GotFish)
		{
			// P2 Wins
			TM.zP2Wins();
		}



		if (p1.GetComponent<CatBurglarPlayers>().GotCat && p2.GetComponent<CatBurglarPlayers>().GotCat)
		{
			//Both players lose
			TM.zP12Lose();
		}

		if (!p1.GetComponent<CatBurglarPlayers>().GotCat && p2.GetComponent<CatBurglarPlayers>().GotCat)
        {
			// P1 Wins
			TM.zP1Wins();
        }

		if (p1.GetComponent<CatBurglarPlayers>().GotCat && !p2.GetComponent<CatBurglarPlayers>().GotCat)
        {
			// P2 Wins
			TM.zP2Wins();
        }
	}
}

