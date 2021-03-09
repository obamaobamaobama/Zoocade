using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyship : MonoBehaviour
{
    public float fireRate;
    public bool readyToShoot = false;
    public float coolDown;
    public GameObject bullet;
    public GameObject bulletClone;
     public static float enemyShipSpeed;
    public Transform parent;

    void Start()
    { 
        enemyShipSpeed = 1.5f;
        readyToShoot = false; 
        coolDown = fireRate;
        InvokeRepeating("MoveEnemy",Time.captureDeltaTime, Time.deltaTime);
       // Debug.Log(parent.childCount);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    { 
       // InUpdate();
      //  SwitchDirection();
        if (readyToShoot == false)
        {
            coolDown -= 1f *Time.deltaTime;
        }
        if (coolDown <= 0)
        {
            coolDown = fireRate;
            readyToShoot = true;
        }
        if(readyToShoot == true)
        {
            bulletClone = Instantiate(bullet, new Vector3(transform.position.x,(transform.position.y - 0.7f),0), transform.rotation) as GameObject;
            readyToShoot = false;
        }
        
    }
    void MoveEnemy()
    {
        parent.position += Vector3.right * enemyShipSpeed * Time.deltaTime;

        foreach(Transform enemy in parent)
        {
            if(enemy.position.x < -4.5f || enemy.position.x > 4.5f)
            {
              enemyShipSpeed = -enemyShipSpeed;  
              return;
            }
        }
    }
}
