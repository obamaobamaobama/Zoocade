using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TriviaGame : MonoBehaviour
{
   public Transform pointer1;
   public Transform pointer2;
   public bool sceneOn;
   public Question[] questions;
   public Answer[] choices;
   public Transform[] spawnPos;
   private static List<Question> allQuestion;
   private static List<Answer> allChoices;
   private static List<Transform> allSpawnPos;
   private Question currentQuestion;
  [SerializeField]
  private AudioSource audioSource;
  [SerializeField]
  private SpriteRenderer audioScene;

  private GameObject correctAnswer;
public static bool pause = false;

   void Start()
   {
      allQuestion = questions.ToList<Question>(); // adding the array to list
      allChoices = choices.ToList<Answer>();
      allSpawnPos = spawnPos.ToList<Transform>();
      GetRandomQuestion();
     //Debug.Log(currentQuestion.question + "is" + currentQuestion.answer);

   }
   void GetRandomQuestion()
   {
      int randQ = Random.Range(0, allQuestion.Count); 
      currentQuestion = allQuestion[randQ];

      audioSource.clip = currentQuestion.question; // set the clip to the question which is an audio file
      audioSource.Play();
      
      int currentAnswer = randQ;

      int randPos = Random.Range(0, allSpawnPos.Count);
       correctAnswer = Instantiate(allChoices[currentAnswer].choices, allSpawnPos[randPos].position, transform.rotation); // instantiate answer

      allChoices.RemoveAt(currentAnswer); // = get the wrong choices
      allSpawnPos.RemoveAt(randPos); //get the other spawn pos
      Instantiate(allChoices[Random.Range(0,allChoices.Count)].choices, allSpawnPos[Random.Range(0,allSpawnPos.Count)].position, transform.rotation); // instantiate other choices

   }
   void FixedUpdate()
   {
       if (sceneOn) { audioScene.enabled = true; }
       if (!sceneOn) { audioScene.enabled = false; }
      CheckAudioIsPlaying();
      CheckWhoWin();
   }
   void CheckAudioIsPlaying()
   {
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
   void CheckWhoWin()
   {
     if(pointer1.position.x == correctAnswer.transform.position.x && pointer2.position.x != correctAnswer.transform.position.x)
     {
        Debug.Log("P1 win");
        pause = true;
     }
     if(pointer2.position.x == correctAnswer.transform.position.x && pointer1.position.x != correctAnswer.transform.position.x)
     {
        Debug.Log("P2 win");
        pause = true;
     }
     if(pause)
     {
        if(pointer1.position.x == 0 && pointer2.position.x != correctAnswer.transform.position.x)
        {
           Debug.Log("P1 win");
        }
        if(pointer2.position.x == 0 && pointer1.position.x != correctAnswer.transform.position.x)
        {
           Debug.Log("P2 win");
        }
     }
   }
}
