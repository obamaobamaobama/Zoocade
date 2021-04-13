using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack1Manager : MonoBehaviour
{
    public GameObject P1;
    public GameObject P2;
    private bool timesUp = false;
    private void Start()
    {
        InvokeRepeating("CheckPlayersAlive", 0.5f, 0.5f);
    }

    private void CheckPlayersAlive()
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
        timesUp = true;
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP12Wins();
    }


}
