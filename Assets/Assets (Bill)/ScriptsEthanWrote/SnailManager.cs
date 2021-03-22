using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnailManager : MonoBehaviour
{

public Transform p1;
public Transform p2;

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
			P1wins();
		}
		if(p2.position.x > p1.position.x)
		{
			P2wins();
		}
		if(p1.position.x == p2.position.x)
		{
			Draw();
		}
	}
	public void P1wins()
	{
		var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		if (scoreText == "P1Wins")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP1Wins();
		}
	}
	public void P2wins()
	{
		var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		if (scoreText == "P2Wins")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP2Wins();
		}
	}
	public void Draw()
	{
		var scoreText = GameObject.Find("Text___").GetComponent<Text>().text;

		if (scoreText == "")
		{
			var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
			TM.zP12Wins();
		}
	}
}
