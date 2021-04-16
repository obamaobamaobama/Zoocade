using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDodgeManager : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

   public void zTimesUp()
   {
      PlayerHP p1Hp = p1.GetComponent<PlayerHP>();
      PlayerHP p2Hp = p2.GetComponent<PlayerHP>();

      if (p1Hp.hp > p2Hp.hp) {P1wins();}
      if (p2Hp.hp > p1Hp.hp) {P2wins();}
      if (p2Hp.hp == p1Hp.hp) {P12wins();}
   }
      void Update()
   {
       if (p1 == null && p2 != null){P2wins();}
       if (p1 != null && p2 == null){P1wins();}
       if (p1 == null && p2 == null){P12Lose();}
   }
   public void P1wins()
   {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP1Wins();
   }
   public void P2wins()
   {
       var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP2Wins();
   }
    public void P12wins()
   {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP12Wins();
   }
    public void P12Lose()
   {
       var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();
        TM.zP12Lose();
   }
}
