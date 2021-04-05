using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBattlePlayers : MonoBehaviour
{
	private Animator _anim;

	private bool touchingDanceBlock = false;
	private int touchingLeftOrRightBlock = 0;
	private bool deleteDanceBlock = false;

	private void Start()
	{
		_anim = this.GetComponent<Animator>();
	}

	public void zLeft()
	{
		if (touchingDanceBlock && touchingLeftOrRightBlock == 1)
		{
			_anim.SetTrigger("Left");
			deleteDanceBlock = true;
		}
	}

	public void zRight()
	{
		if (touchingDanceBlock && touchingLeftOrRightBlock == 2)
		{
			_anim.SetTrigger("Right");
			deleteDanceBlock = true;
		}
	}


	public void Won()
	{
		_anim.SetTrigger("Win");
	}

	public void Lost()
	{
		_anim.SetTrigger("Fail");
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		touchingDanceBlock = true;
		var dbb = collision.gameObject.GetComponent<DanceBlock>();
		var db = dbb.leftBlock;

		if (dbb != null)
		{
			if (db) { touchingLeftOrRightBlock = 1; }
			if (!db) { touchingLeftOrRightBlock = 2; }
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		touchingDanceBlock = false;
		touchingLeftOrRightBlock = 0;
	}


	private void OnTriggerStay2D(Collider2D collision)
	{
		if (deleteDanceBlock)
		{
			Destroy(collision.gameObject);
			deleteDanceBlock = false;
		}
	}
}
