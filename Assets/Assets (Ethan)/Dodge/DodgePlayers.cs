using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgePlayers : MonoBehaviour
{
    private float gravity = 30;
    private float vsp = 0;
	private bool touchingGround = false;
	private Animator _animator;
	[HideInInspector] public bool dead = false;
	public AudioClip jumpSound;
	public AudioClip deathSound;
	private AudioSource _audio;

	private void Start()
	{
		_animator = this.GetComponent<Animator>();
		_audio = this.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!touchingGround)
		{
			vsp -= gravity * Time.deltaTime;
		}

		this.transform.position += new Vector3(0, vsp) * Time.deltaTime;
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (!dead)
		{
			if (collision.GetComponent<DodgeItems>() != null)
			{
				Dead();
			}
			else
			{
				touchingGround = true;
				vsp = 0;
			}
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		touchingGround = false;
	}


	public void zJump()
	{
		if (touchingGround && !dead) { vsp = 10; PlaySound(jumpSound); } else { if (!dead) { vsp = 7.5f; PlaySound(jumpSound); } }
	}

	private void PlaySound(AudioClip _sound)
	{
		_audio.clip = _sound;
		_audio.Play();
	}


	public void Dead()
	{
		_animator.SetTrigger("Dead");
		dead = true;
		PlaySound(deathSound);
	}
}
