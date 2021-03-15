using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketManager : MonoBehaviour
{
    public void zTimesUp()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1Score = GameObject.Find("player 1").GetComponent<PointCalcutator>().points;
		var p2Score = GameObject.Find("player 2").GetComponent<PointCalcutator>().points;

		if (p1Score > p2Score) { TM.zP1Wins(); }
		if (p1Score < p2Score) { TM.zP2Wins(); }
		if (p1Score == p2Score) { TM.zP12Wins(); }
	}
}
