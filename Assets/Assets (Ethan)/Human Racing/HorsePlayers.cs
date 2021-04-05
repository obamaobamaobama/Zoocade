using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorsePlayers : MonoBehaviour
{
	private Animator _anim;
	private float moveSpeedCur = 0.1f;
	private float moveSpeedMin = 0.1f;
	public GameObject myHuman;
	// win is 1, lose is 2
	[HideInInspector] private int winLose = 0;
	private GameObject HRM;

	private void Awake()
	{
		_anim = this.GetComponent<Animator>();
		HRM = GameObject.Find("HumanRacingManager");
	}


	public void zWhip()
	{
		_anim.SetTrigger("Whip");
		moveSpeedCur += 0.2f;
	}


	public void zWin()
	{
		winLose = 1;
		_anim.SetTrigger("Win");
		myHuman.SetActive(false);
	}

	public void zLose()
	{
		winLose = 2;
		_anim.SetTrigger("Lose");
		myHuman.SetActive(false);
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (transform.gameObject.name == "Player 1") { HRM.GetComponent<HumanRacingManager>().player2lost = true; } 
		if (transform.gameObject.name == "Player 2") { HRM.GetComponent<HumanRacingManager>().player1lost = true; } 
	}


		private void Update()
	{
		if (winLose == 0)
		{
			if (moveSpeedCur > moveSpeedMin) { moveSpeedCur -= 0.5f * Time.deltaTime; }
			if (moveSpeedCur < moveSpeedMin) { moveSpeedCur = moveSpeedMin; }

			transform.position += new Vector3(moveSpeedCur, 0) * Time.deltaTime;
		}
	}
}
