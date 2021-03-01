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
}
