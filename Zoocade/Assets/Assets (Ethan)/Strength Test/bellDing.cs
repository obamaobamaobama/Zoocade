using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellDing : MonoBehaviour
{

	private void OnEnable()
	{
		this.GetComponent<AudioSource>().Play();
	}
}
