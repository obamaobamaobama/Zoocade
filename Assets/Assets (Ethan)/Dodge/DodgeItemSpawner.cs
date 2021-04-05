using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeItemSpawner : MonoBehaviour
{
	public GameObject flame;
	public GameObject blade;

	private float spawnSpeed = 0.5f;
	public float moveSpeedd = 5;



	private void Start()
	{
		InvokeRepeating("SpawnItem", spawnSpeed, spawnSpeed);
	}


	private void SpawnItem()
	{
		if (moveSpeedd < 20) { moveSpeedd += 0.25f; }

		var flameOrBlade = Random.Range(0, 1 + 1);

		if (flameOrBlade == 0)
		{
			var item = Instantiate(flame);
			item.GetComponent<DodgeItems>().moveSpeed = moveSpeedd;
			item.GetComponent<Transform>().position = new Vector3(6, -1.22f);
		}

		if (flameOrBlade == 1)
		{
			var item = Instantiate(blade);
			item.GetComponent<DodgeItems>().moveSpeed = moveSpeedd;
			item.GetComponent<Transform>().position = new Vector3(6, 3.9f);
		}
	}
}