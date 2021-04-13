using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack2Manager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private bool timesUp = false;

    public void zTimesUp()
    {
        PointCalcutator pc1 = P1.GetComponent<PointCalcutator>();
        PointCalcutator pc2 = P2.GetComponent<PointCalcutator>();

        if(pc1.points > pc2.points) { P1Wins(); }
        if(pc2.points > pc1.points) { P2Wins(); }
        if(pc1.points == pc2.points) { Draw(); }
    }
    public void P1Wins()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP1Wins();
        timesUp = true;
    }
    public void P2Wins()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP2Wins();
        timesUp = true;
    }
    public void Draw()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP12Wins();
        timesUp = true;
    }
    public void BothDead()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP12Lose();
        timesUp = true;
    }
}
