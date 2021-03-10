using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriviaManager : MonoBehaviour
{
    public SpriteRenderer audioScene;
    public bool sceneOn;
    public AudioClip[] questions;
    public GameObject[] choices;
    public Transform[] spawnPos;
    AudioSource audioSource;

    private void Update()
    {
        if (sceneOn) { audioScene.enabled = true; }
        if (!sceneOn) { audioScene.enabled = false; }
        CheckAudioIsPlaying();

    }
    private void CheckAudioIsPlaying()
    {
        int randQ = Random.Range(0, questions.Length);
        if(audioSource.isPlaying)
        {
            //Debug.Log("is playing");
            sceneOn = true;
        }
        else
        {
            //Debug.Log("finished");
            sceneOn = false;
        }
    }
    private void Start() //Generate question and answer here
    {
        audioSource = GetComponent<AudioSource>();
        int questionNumber = Random.Range(0, questions.Length);
        audioSource.clip = questions[questionNumber];
        audioSource.Play();

        int answer = questionNumber;
        int allChoices = Random.Range(0, choices.Length);
        int randPos = Random.Range(0, spawnPos.Length);
        Instantiate(choices[answer], spawnPos[randPos].position, transform.rotation);

        Instantiate(choices[allChoices], spawnPos[randPos].position, transform.rotation);
    }
}
