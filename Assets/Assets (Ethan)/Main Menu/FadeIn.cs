using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour
{
    
	private void Update()
	{
		if (this.GetComponent<RectTransform>().localScale.x >= 0)
		{
			this.GetComponent<RectTransform>().localScale -= new Vector3(0.01f, 0.01f);
		}
		else
		{
			this.enabled = false;
		}
	}
}
