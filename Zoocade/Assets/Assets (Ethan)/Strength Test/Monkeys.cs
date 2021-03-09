using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkeys : MonoBehaviour
{
	public GameObject monkeysBell;
    private bool monkeyHasHit = false;

	public void zHit()
	{
		if (!monkeyHasHit)
		{
			this.GetComponent<AudioSource>().Play();
			this.GetComponent<Animator>().Play("Monkey Wack");
			monkeysBell.GetComponent<Animator>().Play("Bell Wacked");
			monkeyHasHit = true;
		}
	}


	public void zTimesUp()
	{
		if (GameObject.Find("ControlManager") != null)
		{
			GameObject.Find("ControlManager").GetComponent<ControlManager>().P1A_pressed.Invoke();
		}

		if (GameObject.Find("ControlManager") != null)
		{
			GameObject.Find("ControlManager").GetComponent<ControlManager>().P2A_pressed.Invoke();
		}
	}
}
