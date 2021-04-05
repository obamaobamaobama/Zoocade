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

	private void Start()
	{
		_animator = this.GetComponent<Animator>();
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
		if (touchingGround && !dead) { vsp = 10; } else { vsp = 7.5f; }
	}


	public void Dead()
	{
		_animator.SetTrigger("Dead");
		dead = true;
	}
}
