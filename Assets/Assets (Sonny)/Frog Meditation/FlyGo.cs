using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGo : MonoBehaviour
{
    private float flySpeed;
	public bool flyDrop;
	public bool flyMoveLeft;

	private void Start()
	{
		//flySpeed = GameObject.Find("FrogMeditationManager").GetComponent<FrogMeditationManager>().flySpeed;
		flySpeed = Random.Range(150 / 10, 250 / 10);
		if (!flyMoveLeft) { flySpeed = flySpeed * -1; }
		flyDrop = true;
	}

	private void FixedUpdate()
	{
		if (flyDrop)
		{
			if (this.GetComponent<RectTransform>().position.x < -100)
			{
				var RM = GameObject.Find("FrogMeditationManager");
				RM.GetComponent<FrogMeditationManager>().zTimesUp();
			}
			else
			{
				this.GetComponent<RectTransform>().localPosition += new Vector3(-flySpeed, 0) * Time.deltaTime;
				//AudioSource.PlayClipAtPoint(this.GetComponent<AudioSource>().clip, Camera.main.transform.position);
			}
		}
	}
}
