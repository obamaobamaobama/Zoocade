using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMeditationManager : MonoBehaviour
{
	//public float flySpeed;
	//[SerializeField] private float flyGoTimer;
	//[SerializeField] private bool flyGone = false;

	private void Awake()
	{
		//flySpeed = Random.Range(250, 550);
		//flySpeed = Random.Range(150/5, 250/5);
		//flyGoTimer = Random.Range(2, 5);
	}

	/*private void Update()
	{
		if (!flyGone)
		{
			if (flyGoTimer > 0)
			{
				flyGoTimer -= 1 * Time.deltaTime;
			}
			else
			{
				GameObject.Find("Fly P1").GetComponent<FlyGo>().flyDrop = true;
				GameObject.Find("Fly P2").GetComponent<FlyGo>().flyDrop = true;
				flyGone = true;
			}
		}
	}*/


	public void zTimesUp()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1 = GameObject.Find("FrogMonk P1");
		var p2 = GameObject.Find("FrogMonk P2");
		var p1Score = GameObject.Find("FrogMonk P1").GetComponent<Point_Calculator_Frog>().points;
		var p2Score = GameObject.Find("FrogMonk P2").GetComponent<Point_Calculator_Frog>().points;

		if (p1.GetComponent<Point_Calculator_Frog>().FrogKO && p2.GetComponent<Point_Calculator_Frog>().FrogKO)
		{
			// Both players lose
			TM.zP12Lose();
		}

		if (p1.GetComponent<Point_Calculator_Frog>().FrogKO && !p2.GetComponent<Point_Calculator_Frog>().FrogKO)
		{
			// P2 Wins
			TM.zP2Wins();
		}

		if (!p1.GetComponent<Point_Calculator_Frog>().FrogKO && p2.GetComponent<Point_Calculator_Frog>().FrogKO)
		{
			// P1 Wins
			TM.zP1Wins();
		}

		if (p1Score > p2Score) { TM.zP1Wins(); }
		if (p1Score < p2Score) { TM.zP2Wins(); }
		if (p1Score == p2Score) { TM.zP12Wins(); }
	}
}
