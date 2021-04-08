using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointCalc : MonoBehaviour
{
    public static int P1Score;
    public static int P2Score;
    public Text P1text;
    public Text P2text;

    // Ethan wrote this
    [HideInInspector] public int zP1Score;
    [HideInInspector] public int zP2Score;

   

    // Update is called once per frame
    void Update()
    {
        P1text.text = "P1:" + P1Score;
        P2text.text = "P2:" + P2Score;

        // Ethan wrote this
        zP1Score = P1Score;
        zP2Score = P2Score;
    }
}
