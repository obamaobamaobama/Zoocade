﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBurglarPlayers : MonoBehaviour
{
	private Animator _anim;

	public bool GotFish = false;

	//public void OnTriggerEnter2D(Collider2D col);

	private void Awake()
	{
		_anim = this.GetComponent<Animator>();
	}

	//private void GetFish(GameObject _collision)
	//{
		//_anim.SetBool("FishStole", true);
		//GotFish = true;
		//Destroy(_collision);

		//var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		//if (this.gameObject.name == "CatBurglar P1") { TM.zP1Done(); }
		//if (this.gameObject.name == "CatBurglar P2") { TM.zP2Done(); }
	//}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			_anim.SetBool("Caught", true);
		}
	}
}
