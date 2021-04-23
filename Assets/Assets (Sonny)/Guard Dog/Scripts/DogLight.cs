using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogLight : MonoBehaviour
{
	private Animator _anim;

	public bool Gotcha = false;

	public Collider2D lightTriggerZone;


	private void Awake()
	{
		_anim = this.GetComponent<Animator>();
		lightTriggerZone.enabled = true;
	}
	public void FixedUpdate()
	{
		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Dog_Light_Off"))
		{
			lightTriggerZone.enabled = false;
		}

		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Light_Flash"))
        {
			lightTriggerZone.enabled = true;
        }
	}


	//public void zFlash()
	//{
		//_anim.Play("Light_Flash");
		//lightTriggerZone.enabled = true;
	//}


	private void OnTriggerStay2D(Collider2D collision)
	{
		//Debug.Log("WAH");

		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Light_Flash"))
		{
			CatSpotted(collision.gameObject);
		}

		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Light_Flash"))
		{
			CatSpotted(collision.gameObject);
		}
	}

	private void CatSpotted(GameObject _collision)
	{
		_anim.SetBool("DogLaugh", true);
		Gotcha = true;
		AudioSource.PlayClipAtPoint(this.GetComponent<AudioSource>().clip, Camera.main.transform.position);
		//Destroy(_collision);

		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		if (this.gameObject.name == "CatBurglar P1") { TM.zP1Done(); }
		if (this.gameObject.name == "CatBurglar P2") { TM.zP2Done(); }
	}
}
