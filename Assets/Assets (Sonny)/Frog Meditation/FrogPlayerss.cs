using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogPlayerss : MonoBehaviour
{
    private Animator _anim;

	public bool triedToCatch = false;

	public bool IcaughtFly = false;

	public Collider2D tongueTriggerZone;


	private void Awake()
    {
        _anim = this.GetComponent<Animator>();
		tongueTriggerZone.enabled = false;
	}
	public void FixedUpdate()
    {
		if (!_anim.GetCurrentAnimatorStateInfo(0).IsName("Frog_Tongue"))
		{
			tongueTriggerZone.enabled = false;
		}
	}


    public void zCatch()
    {
        _anim.Play("Frog_Tongue");
		tongueTriggerZone.enabled = true;
    }
	

	private void OnTriggerStay2D(Collider2D collision)
	{
		//Debug.Log("WAH");

		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Frog_Tongue"))
		{
			CatchFly(collision.gameObject);
		}

		if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Frog_Tongue"))
		{
			CatchFly(collision.gameObject);
		}
	}

	private void CatchFly(GameObject _collision)
	{
		_anim.SetBool("Caught", true);
		IcaughtFly = true;
		Destroy(_collision);

		//var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		//if (this.gameObject.name == "FrogMonk P1") { TM.zP1Done(); }
		//if (this.gameObject.name == "FrogMonk P2") { TM.zP2Done(); }
	}
}
