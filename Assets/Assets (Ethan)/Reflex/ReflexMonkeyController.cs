using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReflexMonkeyController : MonoBehaviour
{
	public bool triedToCatch = false;
	public Sprite monkeyCatchSprite1;
	public Sprite monkeyCatchSprite2;
	public Sprite monkeyCatchSprite3;

	public Sprite monkeyWinSprite1;
	public Sprite monkeyWinSprite2;
	public Sprite monkeyWinSprite3;
	public Sprite monkeyWinSprite4;
	public Sprite monkeyWinSprite5;

	public Sprite[] MonkeyWinSprites;

	private bool catchAnimation;

	private Animator animController;

	public bool IcaughtBanana = false;


	private void Awake()
	{
		animController = this.GetComponent<Animator>();
		animController.SetBool("Caught", false);
	}

	public void zCatch()
	{
		if (!triedToCatch)
		{
			//InvokeRepeating("CatchAnim", 0f, 0.05f);
			//animController.clip = animController.GetClip("ReflexMonkeyCatch");
			animController.SetTrigger("Catch");
			//triedToCatch = true;
		}
	}

	/*private void CatchAnim()
	{
		if (catching < 4)
		{
			catching += 1;
			catchAnimation = !catchAnimation;

			if (catchAnimation)
			{
				this.GetComponent<Image>().sprite = monkeyCatchSprite2;
			}
			else
			{
				this.GetComponent<Image>().sprite = monkeyCatchSprite3;
			}
		}
		else
		{
			catching = 0;
			triedToCatch = false;
			this.GetComponent<Image>().sprite = monkeyCatchSprite1;
			CancelInvoke("CatchAnim");
		}
	}*/


	private void OnTriggerStay2D(Collider2D collision)
	{
		//Debug.Log("WAH");

		if (animController.GetCurrentAnimatorStateInfo(0).IsName("ReflexMonkeyCatch"))
		{
			CatchBanana(collision.gameObject);
		}

		if (animController.GetCurrentAnimatorStateInfo(0).IsName("ReflexMonkeyCatchP2"))
		{
			CatchBanana(collision.gameObject);
		}
	}

	private void CatchBanana(GameObject _collision)
	{
		animController.SetBool("Caught", true);
		IcaughtBanana = true;
		Destroy(_collision);

		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		if (this.gameObject.name == "P1") { TM.zP1Done(); }
		if (this.gameObject.name == "P2") { TM.zP2Done(); }
	}
}
