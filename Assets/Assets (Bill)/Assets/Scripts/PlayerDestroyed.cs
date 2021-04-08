using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDestroyed : MonoBehaviour
{
  public static int P1Score;
  public static int P2Score;
    public Animator animator;
    public Transform player;
    public string tagignore;
    public Collider2D myCollider;
    public AudioSource audioManager;

  void Start()
  {
    myCollider = GetComponent<Collider2D>();
  }
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.gameObject.tag == tagignore)
      {
         Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
      }
      else
      {
        myCollider.enabled = false;
        animator.Play("Player explode");

        if (audioManager != null) 
        {
          audioManager.Play();
        }
                          
        
        var currentScene = SceneManager.GetActiveScene().name;
        if(currentScene == "Aesteroid")
        {
          if(this.gameObject.name == "Player 1")
          {
            GameObject.Find("Aesteroid Manager").GetComponent<AesteroidManager>().CheckWhoWin(2);
           
          }
          if(this.gameObject.name == "Player 2")
          {
            GameObject.Find("Aesteroid Manager").GetComponent<AesteroidManager>().CheckWhoWin(1);
           
          }
        }
      }
      
       if (collision.gameObject.tag =="P1")
        {
          Debug.Log("p1 hit it");
          pointCalc.P1Score += 1; //P1 and P2 scores are static
        }
        if (collision.gameObject.tag =="P2")
        {
          pointCalc.P2Score += 1;
        }
    }
}
