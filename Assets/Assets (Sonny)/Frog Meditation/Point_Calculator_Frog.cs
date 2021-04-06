using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point_Calculator_Frog : MonoBehaviour
{
    public Text p1txt;
    public int points = 0;
    public string player1or2;
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "plus")
        {
            points += 1;
            Destroy(col.gameObject);
        }
        if (col.tag == "minus")
        {
            points -= 1;
            Destroy(col.gameObject);
        }
        if (col.tag == "Bomb")
        {
            GameObject.Find("FrogMonk P1");
            Destroy(gameObject);
            Destroy(this);

            GameObject.Find("FrogMonk P2");
            Destroy(gameObject);
            Destroy(this);

            Destroy(col.gameObject);
        }
    }
    void Update()
    {
        p1txt.text = player1or2 + points;
    }
}