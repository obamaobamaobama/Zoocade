using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrogMonkController : MonoBehaviour
{
	public bool triedToCatch = false;
	public Sprite frogCatchSprite1;
	public Sprite frogCatchSprite2;
	public Sprite frogCatchSprite3;

	public Sprite frogWinSprite1;

	public Sprite[] FrogWinSprites;

	private bool catchAnimation;

	private Animator animController;

	public bool IcaughtFly = false;


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

		if (animController.GetCurrentAnimatorStateInfo(0).IsName("FrogMonkCatch"))
		{
			CatchFly(collision.gameObject);
		}

		if (animController.GetCurrentAnimatorStateInfo(0).IsName("FrogMonkCatchP2"))
		{
			CatchFly(collision.gameObject);
		}
	}

	private void CatchFly(GameObject _collision)
	{
		animController.SetBool("Caught", true);
		IcaughtFly = true;
		Destroy(_collision);

		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		if (this.gameObject.name == "FrogMonk P1") { TM.zP1Done(); }
		if (this.gameObject.name == "FrogMonk P2") { TM.zP2Done(); }
	}
}
