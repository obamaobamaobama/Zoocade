﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
			var imaage = this.GetComponent<Image>();
			imaage.enabled = false;
			this.enabled = false;
		}
	}
}
