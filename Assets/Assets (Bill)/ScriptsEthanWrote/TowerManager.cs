using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //Bill Wrote this
    public Transform p1H;
    public Transform p2H;
    [SerializeField] float P1timer = 3f;
    [SerializeField] float P2timer = 3f;
    bool GameOver = false;
    void FixedUpdate()
    {
        P1timer = Mathf.Clamp(P1timer,0,3);
        P2timer = Mathf.Clamp(P2timer,0,3);
        
        if(GameOver) {return;}

        if(p1H.position.y >= 2.9f) {P1timer -= 1f * Time.deltaTime;}
        else{P1timer = 3f;}

        if(p2H.position.y >= 2.9f) {P2timer -= 1f * Time.deltaTime;}
        else{P2timer = 3f;}

        if(P1timer <= 0) {P1Win();}
        if(P2timer <= 0) {P2win();}
    }
    public void zTimesUp()
    {
        if(p1H.position.y > p2H.position.y)
        {
            P1Win();
            
            
        }
         if(p2H.position.y > p1H.position.y)
         {
             P2win();
             
         }
         if(p2H.position.y == p1H.position.y)
         {
             Draw();
             
         }
    }
    public void P1Win()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		TM.zP1Wins();
        GameOver = true;
    }
    public void P2win()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		TM.zP2Wins();
        GameOver = true;
    }
    public void Draw()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
		TM.zP12Wins();
        GameOver = true;
    }
}
