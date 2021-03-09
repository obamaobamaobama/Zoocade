using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyUp : MonoBehaviour
{
	public bool childState = true;

	private void Start()
	{
		InvokeRepeating("Flash", 1, 1);
	}


	private void Flash()
	{
		for (int i = 0; i < transform.childCount; i++)
		{
			var child = transform.GetChild(i).gameObject;
			if (child != null)
			{
				childState = !childState;
				//child.SetActive(childState);
				child.GetComponent<Image>().enabled = childState;
				// not flashing?
			}
		}
	}
}
