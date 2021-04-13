using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnailManager : MonoBehaviour
{

public Transform p1;
public Transform p2;

	private bool p1winYeet = false;
	private bool p2winYeet = false;

	private void FixedUpdate()
	{
		if(p1.position.x >=3)
		{
			P1wins();
		}
		if(p2.position.x >=3)
		{
			P2wins();
		}
	}

	public void zTimesUp()
	{
		if(p1.position.x > p2.position.x)
		{
			if (!p1winYeet)
			{
				P1wins();
				p1winYeet = true;
			}
		}
		if(p2.position.x > p1.position.x)
		{
			if (!p2winYeet)
			{
				P2wins();
				p2winYeet = true;
			}
		}
		if(p1.position.x == p2.position.x)
		{
			if (!p1winYeet && !p2winYeet)
			{
				p1winYeet = true;
				p2winYeet = true;
				Draw();
			}
		}
	}
	public void P1wins()
	{
		Debug.Log("FUCK");
		//var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		Debug.Log("FUCK FUCK");
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		TM.zP1Wins();

		/*if (scoreText == "P1Wins")
		{
			Debug.Log("FUCK FUCK");
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP1Wins();
		}*/
	}
	public void P2wins()
	{
		//var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		TM.zP2Wins();

		/*if (scoreText == "P2Wins")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP2Wins();
		}*/
	}
	public void Draw()
	{
		//var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		TM.zP12Wins();


		/*if (scoreText == "")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP12Wins();
		}*/
	}
}
