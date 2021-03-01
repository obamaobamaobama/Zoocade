using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bellMeter : MonoBehaviour
{
    private bool canMove = true;
    private bool moveUp = true;

    
    void Update()
    {
        if (canMove)
        {
            if (moveUp)
            {
                if (transform.localScale.y < 45)
                {
                    transform.localScale = transform.localScale += new Vector3(0, 120 * Time.deltaTime);
                }
                else
                {
                    moveUp = false;
                }
            }



            if (!moveUp)
            {
                if (transform.localScale.y > 1)
                {
                    transform.localScale = transform.localScale -= new Vector3(0, 120 * Time.deltaTime);
                }
                else
                {
                    moveUp = true;
                }
            }
        }
    }



    public void zStopMeter()
	{
        this.GetComponent<AudioSource>().Play();
        canMove = false;
        var score = (transform.localScale.y * 2) + 10;
        if (score < 0) { score = 0; transform.localScale = new Vector3(1, 0.5f); }
        if (score > 100) { score = 100; transform.localScale = new Vector3(1, 45); }
        Debug.Log(Mathf.Round(score));
	}
}
