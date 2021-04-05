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
	private float spawnSpeed = 0.35f;




	private void Start()
	{
		InvokeRepeating("SpawnBlock", spawnSpeed, spawnSpeed);
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
			db1.GetComponent<Transform>().position = new Vector3(-4.26f, 5.6f);
			db1.GetComponent<DanceBlock>().p1p2 = 1;

			db2.GetComponent<DanceBlock>().leftBlock = true;
			db2.GetComponent<SpriteRenderer>().sprite = p2a;
			db2.GetComponent<Transform>().position = new Vector3(0.74f, 5.6f);
			db2.GetComponent<DanceBlock>().p1p2 = 2;
		}

		if (leftOrRight == 1)
		{
			db1.GetComponent<DanceBlock>().leftBlock = false;
			db1.GetComponent<SpriteRenderer>().sprite = p1b;
			db1.GetComponent<Transform>().position = new Vector3(-0.9f, 5.6f);
			db1.GetComponent<DanceBlock>().p1p2 = 1;

			db2.GetComponent<DanceBlock>().leftBlock = false;
			db2.GetComponent<SpriteRenderer>().sprite = p2b;
			db2.GetComponent<Transform>().position = new Vector3(4.1f, 5.6f);
			db2.GetComponent<DanceBlock>().p1p2 = 2;
		}

		//var speeed = GameObject.Find("DanceBattleManager").GetComponent<DanceBattleManager>().danceBlockSpeed;
		//spawnSpeed = 0.35f;
		//if (speeed < 10f)	{ spawnSpeed = 0.35f; }
		//if (speeed < 7.5f)	{ spawnSpeed = 0.5f; }
		//if (speeed < 5f)	{ spawnSpeed = 0.75f; }
		//if (speeed < 2.5f)	{ spawnSpeed = 1f; }
		//Invoke("SpawnBlock", spawnSpeed);
	}
}
