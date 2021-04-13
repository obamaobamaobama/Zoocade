using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreedomManager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private bool timesUp = false;

    private void Update()
    {
        if (!timesUp)
        {
            var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

            if (P1 != null && P2 == null) { TM.zP1Wins(); }
            if (P1 == null && P2 != null) { TM.zP2Wins(); }
            if (P1 == null && P2 == null) { TM.zP12Lose(); }
        }
    }

    public void zTimesUp()
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        PlayerHP p1Hp = P1.GetComponent<PlayerHP>();
        PlayerHP p2Hp = P2.GetComponent<PlayerHP>();

        if (p1Hp.hp > p2Hp.hp) { TM.zP1Wins(); }
        if (p2Hp.hp > p1Hp.hp) { TM.zP2Wins(); }
        if (p2Hp.hp == p1Hp.hp) { TM.zP12Wins(); }

    }
}
