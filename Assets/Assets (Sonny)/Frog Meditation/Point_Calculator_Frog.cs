using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//A simple script for attributing score points and calling animation states when the Player Frog's tongue collides with an object.

public class Point_Calculator_Frog : MonoBehaviour
{
    public Text p1txt;
    public int points = 0;
    public string player1or2;

    public bool FrogKO = false;

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "plus")
        {
            points += 1;
            Destroy(col.gameObject);
            GetComponent<Animator>().Play("Frog_Splat");
        }
        if (col.tag == "minus")
        {
            points -= 1;
            Destroy(col.gameObject);
        }
        if (col.tag == "Bomb")
        {
            Debug.Log("Bomb");

           // GameObject.Find("FrogMonk P1");
          //  Destroy(gameObject);
          //  Destroy(this);

          //  GameObject.Find("FrogMonk P2");
          //  Destroy(gameObject);
         //   Destroy(this);

            Destroy(col.gameObject);

            GetComponent<Animator>().Play("Frog_Destroy");

            FrogKO = true;

            GameObject.Find("Control_Manager").GetComponent<ControlManager>().enabled = false;

            var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
            if (this.gameObject.name == "FrogMonk P1") { TM.zP1Done(); TM.zP2Wins(); }
            if (this.gameObject.name == "FrogMonk P2") { TM.zP2Done(); TM.zP1Wins(); }

        }
    }
    void Update()
    {
        p1txt.text = player1or2 + points;
    }
}