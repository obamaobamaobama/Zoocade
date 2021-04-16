using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBattlePlayers : MonoBehaviour
{
	private Animator _anim;

	private bool touchingDanceBlock = false;
	private int touchingLeftOrRightBlock = 0;
	private bool deleteDanceBlock = false;

	private AudioSource _audio;
	public AudioClip dance1;
	public AudioClip dance2;

	private void Start()
	{
		_anim = this.GetComponent<Animator>();
		_audio = this.GetComponent<AudioSource>();
	}

	public void zLeft()
	{
		if (touchingDanceBlock && touchingLeftOrRightBlock == 1)
		{
			_anim.SetTrigger("Left");
			deleteDanceBlock = true;
			if (this.gameObject.name == "DancerPlayer1") { PlaySound(dance1); }
			}
	}

	public void zRight()
	{
		if (touchingDanceBlock && touchingLeftOrRightBlock == 2)
		{
			_anim.SetTrigger("Right");
			deleteDanceBlock = true;
			if (this.gameObject.name == "DancerPlayer1") { PlaySound(dance2); }
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


	private void PlaySound(AudioClip _sound)
	{
		_audio.clip = _sound;
		_audio.Play();
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
