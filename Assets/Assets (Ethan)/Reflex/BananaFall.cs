using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaFall : MonoBehaviour
{
    private float bananaFallSpeed;
	public bool bananaDrop;

	private void Start()
	{
		bananaFallSpeed = GameObject.Find("ReflexManager").GetComponent<ReflexManager>().bananaSpeed;
	}

	private void Update()
	{
		if (bananaDrop)
		{
			if (this.GetComponent<RectTransform>().position.y < -150)
			{
				var RM = GameObject.Find("ReflexManager");
				RM.GetComponent<ReflexManager>().zTimesUp();
			}
			else
			{
				this.GetComponent<RectTransform>().localPosition += new Vector3(0, -bananaFallSpeed) * Time.deltaTime;
			}
		}
	}
}
