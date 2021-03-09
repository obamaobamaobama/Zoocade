using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScene : MonoBehaviour
{
    public SpriteRenderer audioScene;
    public bool sceneOn;
    public AudioClip[] questions;
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
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = questions[Random.Range(0, questions.Length)];
        audioSource.Play();
      
    }
}
