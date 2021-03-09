using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellDing : MonoBehaviour
{
	public GameObject hideText;

    private void OnEnable()
	{
		this.GetComponent<AudioSource>().Play();
		hideText.SetActive(true);
	}
}
