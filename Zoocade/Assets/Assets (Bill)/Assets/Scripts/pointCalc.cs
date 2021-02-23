using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pointCalc : MonoBehaviour
{
    [SerializeField]
    public static int P1Score;
    public static int P2Score;
    public Text P1text;
    public Text P2text;
   

    // Update is called once per frame
    void Update()
    {
        P1text.text = "P1:" + P1Score;
        P2text.text = "P2:" + P2Score;
    }
}
