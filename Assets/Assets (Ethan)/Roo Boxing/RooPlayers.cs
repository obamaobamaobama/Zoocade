using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RooPlayers : MonoBehaviour
{
    private Animator _anim;
	public int health = 10;
	[HideInInspector] public bool dead = false;
	public bool blocking;
	public bool punching;

	private void Awake()
	{
		_anim = this.GetComponent<Animator>();
	}


	public void zBlock()
	{
		_anim.SetTrigger("Block");
		blocking = true;
		//CancelInvoke("StopBlocking");
		CancelInvoke();
		Invoke("StopBlocking", 0.10f);
	}

	public void zPunch()
	{
		punching = true;
		_anim.SetTrigger("Punch");
		//CancelInvoke("StopPunching");
		CancelInvoke();
		Invoke("StopPunching", 0.10f);
	}

	public void Punched()
	{
		if (health > 0)
		{
			health -= 1;
		}
		else
		{
			dead = true;
			_anim.SetTrigger("Dead");
		}
	}


	public void zPunchReleased() { if (punching) { punching = false; } }
	public void zBlockReleased() { if (blocking) { blocking = false; } }



	private void StopBlocking() { blocking = false; }
	private void StopPunching() { punching = false; }
}
