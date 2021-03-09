using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class players : MonoBehaviour
{
	public Object sceneTransfer;

	public Animator animator;

	public AudioSource audiodata;
	public AudioClip playerGood;
	public AudioClip playerBaad;
	public AudioClip flap;

	public AudioClip loseGame;

	public int microPoints;

	private bool alive = true;
	private float vsp;
	public int myScore;

	

	public void Start()
	{
		audiodata = this.GetComponent<AudioSource>();

		animator = this.GetComponent<Animator>();
	}


	private void Update()
	{
		vsp -= 0.05f;

		transform.position = transform.position + new Vector3(0, vsp * Time.deltaTime);
	}


	public void zUp()
	{
		if (alive)
		{
			vsp = 1.75f;
			animator.Play("Bird Flap");
			audiodata.clip = flap;
			audiodata.Play();
		}
	}


	public void zDown()
	{
		if (alive)
		{
			if (vsp > 0) { vsp = 0; }

			vsp -= 0.025f;
		}
	}


	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Obstacle" && alive)
		{
			audiodata.clip = playerBaad;
			audiodata.Play();
			Debug.Log("contact");
			alive = false;
			//audiodata.clip = loseGame;
			//audiodata.Play();
			Invoke("LoadScene", 2f);

			animator.Play("Bird Dead");
		}


		if (collision.tag == "Reward" && alive)
		{
			audiodata.clip = playerGood;
			audiodata.Play();
			Debug.Log("reward");
			myScore += 1;
		}
	}


	private void LoadScene()
	{
		//SceneManager.LoadScene(sceneTransfer.name, LoadSceneMode.Single);
	}
}
