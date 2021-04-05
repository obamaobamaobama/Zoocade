using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeItems : MonoBehaviour
{
	[HideInInspector] public float moveSpeed = 5;

	private void Update()
	{
		this.transform.position -= new Vector3(moveSpeed, 0) * Time.deltaTime;

		if (this.transform.position.x < -6)
		{
			Destroy(this.gameObject);
		}
	}
}
