using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceBlock : MonoBehaviour
{
    private float speed;
    private GameObject speedManager;
    [HideInInspector] public int p1p2 = 0;
    private GameObject DBM;

    // true if left, false if right
    [HideInInspector] public bool leftBlock;


	private void Start()
	{
        speedManager = GameObject.Find("DanceBattleManager");
        DBM = GameObject.Find("DanceBattleManager");
    }

	void Update()
    {
        speed = speedManager.GetComponent<DanceBattleManager>().danceBlockSpeed;

        transform.position -= new Vector3(0, speed) * Time.deltaTime;

        if (transform.position.y < -5.6f)
		{
            if (p1p2 == 1)
            {
                DBM.GetComponent<DanceBattleManager>().player1lost = true;
            }

            if (p1p2 == 2)
            {
                DBM.GetComponent<DanceBattleManager>().player2lost = true;
            }

            Destroy(this.gameObject);
		}


        if (DBM.GetComponent<DanceBattleManager>().gameOver == true)
		{
            Destroy(this);
		}
    }
}
