using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsController : MonoBehaviour
{
	private Animator _anim;

	public Collider2D scissorsTriggerZone;

	public int biteDamage = 5;


	private void Awake()
	{
		_anim = this.GetComponent<Animator>();
		scissorsTriggerZone.enabled = false;
	}
	public void FixedUpdate()
	{
		if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Scissors"))
		{
			scissorsTriggerZone.enabled = false;
		}
	}


	public void zSnip()
	{
		_anim.Play("Scissors");
		scissorsTriggerZone.enabled = true;
	}


	//private void OnTriggerStay2D(Collider2D collision)
	//{
		//Debug.Log("WAH");

		//if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Scissors"))
		//{
		//	CutHair(collision.gameObject);
		//}

		//if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Scissors"))
		//{
		//	CutHair(collision.gameObject);
		//}

	//}


	private void OnTriggerStay2D(Collider2D _collision)
	{ 
		if (_collision.gameObject.tag == "Enemy")
		{
		     if (_collision.gameObject.GetComponent<SheepHealth>() == true)
            {
				_collision.gameObject.GetComponent<SheepHealth>().TakeDamage(biteDamage);
			}
		}
		//_anim.SetBool("Caught", true);
		//IcaughtFly = true;
		//Destroy(_collision);

		//var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		//if (this.gameObject.name == "Scissors P1") { TM.zP1Done(); }
		//if (this.gameObject.name == "Scissorsk P2") { TM.zP2Done(); }
	}
}
