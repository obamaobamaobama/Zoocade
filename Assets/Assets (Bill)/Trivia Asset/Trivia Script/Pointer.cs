using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public float answerPosX;
    public void zOptionA()
    {
        if (TriviaGame.pause)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(-answerPosX, transform.position.y);
            TriviaGame.pause = true;
        }
    }
    public  void zOptionB()
    {
        if (TriviaGame.pause)
        {
            return;
        }
        else
        {
            transform.position = new Vector3(answerPosX,transform.position.y);
            TriviaGame.pause = true;
        }
    }
}
