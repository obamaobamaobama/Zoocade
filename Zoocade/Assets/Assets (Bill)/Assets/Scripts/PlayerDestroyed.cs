using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyed : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public string tagignore;
    public Collider2D myCollider;

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
        animator.Play("Player explode"); //*E The behavior on the animator tab have the destory script (basically destroy gameobject after animation finished playing). here you can try to add a player lost method, but this script is also on enemyships
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
