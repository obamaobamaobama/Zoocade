using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogMeditationManager : MonoBehaviour
{
	public float flySpeed;
	[SerializeField] private float flyGoTimer;
	[SerializeField] private bool flyGone = false;

	private void Awake()
	{
		//flySpeed = Random.Range(250, 550);
		flySpeed = Random.Range(150, 250);
		flyGoTimer = Random.Range(2, 5);
	}

	private void Update()
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
	}


	public void zTimesUp()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1 = GameObject.Find("FrogMonk P1");
		var p2 = GameObject.Find("FrogMonk P2");

		if (p1.GetComponent<FrogMonkController>().IcaughtFly && p2.GetComponent<FrogMonkController>().IcaughtFly)
		{
			// Both players win
			TM.zP12Wins();
		}

		if (!p1.GetComponent<FrogMonkController>().IcaughtFly && !p2.GetComponent<FrogMonkController>().IcaughtFly)
		{
			// Both players lose
			TM.zP12Wins();
		}

		if (p1.GetComponent<FrogMonkController>().IcaughtFly && !p2.GetComponent<FrogMonkController>().IcaughtFly)
		{
			// P1 Wins
			TM.zP1Wins();
		}

		if (!p1.GetComponent<FrogMonkController>().IcaughtFly && p2.GetComponent<FrogMonkController>().IcaughtFly)
		{
			// P2 Wins
			TM.zP2Wins();
		}
	}
}
