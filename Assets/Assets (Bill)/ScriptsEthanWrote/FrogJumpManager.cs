using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogJumpManager : MonoBehaviour
{
	private Object P1;
	private Object P2;


	private void Start()
	{
		InvokeRepeating("CheckPlayersAlive", 0.25f, 0.25f);
	}

	private void CheckPlayersAlive()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

		if (GameObject.Find("player 1") != null) { P1 = GameObject.Find("player 1").GetComponent<Rigidbody2D>(); }
		if (GameObject.Find("player 2") != null) { P2 = GameObject.Find("player 2").GetComponent<Rigidbody2D>(); }

		if (P1 != null && P2 == null) { TM.zP1Wins(); }
		if (P1 == null && P2 != null) { TM.zP2Wins(); }
	}

	public void zTimesUp()
	{
		CheckPlayersAlive();
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		if (P1 != null && P2 != null) { TM.zP12Wins(); }
	}
}
