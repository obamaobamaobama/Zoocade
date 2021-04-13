using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepBarberManager : MonoBehaviour
{
    public void zTimesUp()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        var p1 = GameObject.Find("Sheep_Afro P1");
        var p2 = GameObject.Find("Sheep_Afro P2");

		if (p1.GetComponent<SheepHealth>().HairCut && p2.GetComponent<SheepHealth>().HairCut)
		{
			// Both players win
			TM.zP12Wins();
		}

		if (!p1.GetComponent<SheepHealth>().HairCut && !p2.GetComponent<SheepHealth>().HairCut)
        {
			//Both players lose
			//TM.zP12Lose();
			TM.zP12Wins();
        }

		if (p1.GetComponent<SheepHealth>().HairCut && !p2.GetComponent<SheepHealth>().HairCut)
		{
			// P1 Wins
			TM.zP1Wins();
		}

		if (!p1.GetComponent<SheepHealth>().HairCut && p2.GetComponent<SheepHealth>().HairCut)
		{
			// P2 Wins
			TM.zP2Wins();
		}
	}
}
