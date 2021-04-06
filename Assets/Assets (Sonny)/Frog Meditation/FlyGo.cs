using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGo : MonoBehaviour
{
    private float flySpeed;
	public bool flyDrop;

	private void Start()
	{
		flySpeed = GameObject.Find("FrogMeditationManager").GetComponent<FrogMeditationManager>().flySpeed;
	}

	private void Update()
	{
		if (flyDrop)
		{
			if (this.GetComponent<RectTransform>().position.x < -7)
			{
				var RM = GameObject.Find("FrogMeditationManager");
				RM.GetComponent<FrogMeditationManager>().zTimesUp();
			}
			else
			{
				this.GetComponent<RectTransform>().localPosition += new Vector3(0, -flySpeed) * Time.deltaTime;
			}
		}
	}
}
