using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBlockSpawner : MonoBehaviour
{
    public Sprite p1a;
    public Sprite p1b;
    public Sprite p2a;
    public Sprite p2b;
	public GameObject DanceBlock;




	private void Start()
	{
		InvokeRepeating("SpawnBlock", 1f, 1f);
	}


	private void SpawnBlock()
	{
		var db1 = Instantiate(DanceBlock);
		var db2 = Instantiate(DanceBlock);



		var leftOrRight = Random.Range(0, 1+1);

		if (leftOrRight == 0)
		{
			db1.GetComponent<DanceBlock>().leftBlock = true;
			db1.GetComponent<SpriteRenderer>().sprite = p1a;
			db1.GetComponent<Transform>().position = new Vector3(-4.26f, 0);

			db2.GetComponent<DanceBlock>().leftBlock = true;
			db2.GetComponent<SpriteRenderer>().sprite = p2a;
			db2.GetComponent<Transform>().position = new Vector3(0.74f, 0);
		}

		if (leftOrRight == 1)
		{
			db1.GetComponent<DanceBlock>().leftBlock = false;
			db1.GetComponent<SpriteRenderer>().sprite = p1b;
			db1.GetComponent<Transform>().position = new Vector3(-0.9f, 0);

			db2.GetComponent<DanceBlock>().leftBlock = false;
			db2.GetComponent<SpriteRenderer>().sprite = p2b;
			db2.GetComponent<Transform>().position = new Vector3(4.1f, 0);
		}
	}
}
