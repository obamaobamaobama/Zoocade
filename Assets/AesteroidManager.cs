using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AesteroidManager : MonoBehaviour
{
    public void CheckWhoWin(int _player)
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
       

        if(_player == 1)
        {
             TM.zP1Wins();
        }
        
        if(_player == 2)
        {
             TM.zP2Wins();
        }
        if(_player == 3)
        {
             TM.zP12Wins();
        }

        // *Bill* *BUG*
        // Need to handle when both players die at the same time
    }
    public void zTimesUp()
    {
         CheckWhoWin(3);
    }
}
