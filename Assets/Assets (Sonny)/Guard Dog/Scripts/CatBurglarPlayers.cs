using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBurglarPlayers : MonoBehaviour
{
	private Animator _anim;

	public bool GotFish = false;

	public bool GotCat = false;

	public Collider2D burglarTriggerZone;

	//public void OnTriggerEnter2D(Collider2D col);

	private void Awake()
	{
		_anim = this.GetComponent<Animator>();
		burglarTriggerZone.enabled = true;
	}
	public void FixedUpdate()
    {
		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Cat_Caught"))
        {
			burglarTriggerZone.enabled = false;
        }
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
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

		if (collision.gameObject.tag == "Enemy")
		{
			_anim.SetBool("Caught", true);
			GotCat = true;
			GameObject.Find("Control_Manager").GetComponent<ControlManager>().enabled = false;
			if (this.gameObject.name == "CatBurglar P1") { TM.zP1Done(); }
			if (this.gameObject.name == "CatBurglar P2") { TM.zP2Done(); }
		}

		if (collision.gameObject.tag == "fish")
        {
			_anim.SetBool("FishStole", true);
			GotFish = true;
			GameObject.Find("Control_Manager").GetComponent<ControlManager>().enabled = false;
			if (this.gameObject.name == "CatBurglar P1") { TM.zP1Done(); }
			if (this.gameObject.name == "CatBurglar P2") { TM.zP2Done(); }
		}
	}
}
