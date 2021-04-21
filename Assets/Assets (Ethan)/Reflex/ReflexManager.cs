using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexManager : MonoBehaviour
{
    public float bananaSpeed;
	[SerializeField] private float bananaFallTimer;
	[SerializeField] private bool bananaFell = false;

	private AudioSource _audio;
	public AudioClip soundBananaFall;

	private void Awake()
	{
		//bananaSpeed = Random.Range(250, 750);
		bananaSpeed = Random.Range(250, 550);
		bananaFallTimer = Random.Range(2, 5);
		_audio = this.GetComponent<AudioSource>();
	}

	private void Update()
	{
		if (!bananaFell)
		{
			if (bananaFallTimer > 0)
			{
				bananaFallTimer -= 1 * Time.deltaTime;
			}
			else
			{
				GameObject.Find("P1 Banana").GetComponent<BananaFall>().bananaDrop = true;
				GameObject.Find("P2 Banana").GetComponent<BananaFall>().bananaDrop = true;
				bananaFell = true;
				_audio.clip = soundBananaFall;
				_audio.Play();
			}
		}
	}


	public void zTimesUp()
	{
		var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		var p1 = GameObject.Find("P1");
		var p2 = GameObject.Find("P2");

		if (p1.GetComponent<ReflexMonkeyController>().IcaughtBanana && p2.GetComponent<ReflexMonkeyController>().IcaughtBanana)
		{
			// Both players win
			TM.zP12Wins();
		}

		if (!p1.GetComponent<ReflexMonkeyController>().IcaughtBanana && !p2.GetComponent<ReflexMonkeyController>().IcaughtBanana)
		{
			// Both players lose
			TM.zP12Wins();
		}

		if (p1.GetComponent<ReflexMonkeyController>().IcaughtBanana && !p2.GetComponent<ReflexMonkeyController>().IcaughtBanana)
		{
			// P1 Wins
			TM.zP1Wins();
		}

		if (!p1.GetComponent<ReflexMonkeyController>().IcaughtBanana && p2.GetComponent<ReflexMonkeyController>().IcaughtBanana)
		{
			// P2 Wins
			TM.zP2Wins();
		}
	}
}
