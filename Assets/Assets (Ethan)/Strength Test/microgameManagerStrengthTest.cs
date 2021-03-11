using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class microgameManagerStrengthTest : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;

	[SerializeField] private float P1Score;
	[SerializeField] private float P2Score;

	
	public void zWHOWON()
	{
		Invoke("Boop", 0.5f);
	}

	private void Boop()
	{
		P1Score = P1.GetComponent<bellMeter>().score;
		P2Score = P2.GetComponent<bellMeter>().score;

		if (P1Score > 0 && P2Score > 0)
		{
			if (P1Score == P2Score)
			{
				var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
				TM.zP12Wins();

				this.enabled = false;
			}

			if (P1Score > P2Score)
			{
				var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
				TM.zP1Wins();

				this.enabled = false;
			}

			if (P1Score < P2Score)
			{
				var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
				TM.zP2Wins();

				this.enabled = false;
			}
		}
	}
}
