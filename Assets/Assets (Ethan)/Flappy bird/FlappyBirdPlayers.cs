using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyBirdPlayers : MonoBehaviour
{
	public Animator animator;

	public AudioSource audiodata;
	public AudioClip playerGood;
	public AudioClip playerBaad;
	public AudioClip flap;

	public AudioClip loseGame;

	public int microPoints;

	public bool alive = true;
	[SerializeField] private float vsp;
	public int myScore;

	

	public void Start()
	{
		audiodata = this.GetComponent<AudioSource>();

		animator = this.GetComponent<Animator>();
	}


	private void Update()
	{
		//vsp -= (0.05f * Time.deltaTime);
		vsp -= (5f * Time.deltaTime);

		transform.position = transform.position + new Vector3(0, vsp * Time.deltaTime);

		if (this.transform.position.y < -1.75f || this.transform.position.y > 1.75f)
		{
			if (alive)
			{
				audiodata.clip = playerBaad;
				audiodata.Play();
				alive = false;

				animator.Play("Bird Dead");
			}
		}
	}


	public void zUp()
	{
		if (alive)
		{
			if (vsp < 0) { vsp = 0; }
			//vsp = 0.0175f;
			//vsp = 1.75f * Time.deltaTime;
			vsp = 2;
			animator.Play("Bird Flap");
			audiodata.clip = flap;
			audiodata.Play();
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Obstacle" && alive)
		{
			audiodata.clip = playerBaad;
			audiodata.Play();
			alive = false;
			//audiodata.clip = loseGame;
			//audiodata.Play();

			animator.Play("Bird Dead");
		}


		if (collision.tag == "Reward" && alive)
		{
			audiodata.clip = playerGood;
			audiodata.Play();
			//Debug.Log("reward");
			myScore += 1;
		}
	}
}
