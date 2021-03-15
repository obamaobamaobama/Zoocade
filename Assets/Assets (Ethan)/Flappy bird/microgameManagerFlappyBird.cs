using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class microgameManagerFlappyBird : MonoBehaviour
{
    public float pipeMovespeed;
    public GameObject pipe;

    private GameObject p1;
    private GameObject p2;

    private bool winner = false;

	private void Awake()
	{
        p1 = GameObject.Find("Player1");
        p2 = GameObject.Find("Player2");
	}

	private void Start()
    {
        SpawnPipe();
        InvokeRepeating("CheckForWinners", 0.3f, 0.3f);
    }

    private void SpawnPipe()
    {
        if (pipeMovespeed < 5) { pipeMovespeed += 0.2f; }
        Invoke("SpawnPipe", 1 + (pipeMovespeed/10));
        Vector3 spawnPos = new Vector3(1.66f, 0, 0);
        Instantiate(pipe, spawnPos, transform.rotation);
    }

	private void CheckForWinners()
	{
        if (!winner)
        {
            if (!p1.GetComponent<FlappyBirdPlayers>().alive)
            {
                if (p1.GetComponent<FlappyBirdPlayers>().myScore < p2.GetComponent<FlappyBirdPlayers>().myScore)
                {
                    // p2 wins
                    var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
                    TM.zP2Wins();

                    this.enabled = false;

                    winner = true;
                }
            }


            if (!p2.GetComponent<FlappyBirdPlayers>().alive)
            {
                if (p1.GetComponent<FlappyBirdPlayers>().myScore > p2.GetComponent<FlappyBirdPlayers>().myScore)
                {
                    // p1 wins
                    var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
                    TM.zP1Wins();

                    this.enabled = false;

                    winner = true;
                }
            }


            if (!p1.GetComponent<FlappyBirdPlayers>().alive && !p2.GetComponent<FlappyBirdPlayers>().alive)
            {
                // both win from dying
                var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
                TM.zP12Wins();

                this.enabled = false;

                winner = true;
            }
        }
	}


    public void zTimesUp()
	{
        if (!winner)
        {
            if (p1.GetComponent<FlappyBirdPlayers>().alive && p2.GetComponent<FlappyBirdPlayers>().alive)
			{
                // both win from surviving timer
                var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
                TM.zP12Wins();

                this.enabled = false;
            }
        }
	}
}
