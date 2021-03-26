using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    public float rotSpeed;
    
    
    public GameObject gun;
    public float angle;
    public float min;
    public float max;
    //shooting things stuff
    public GameObject bullet;
    public GameObject bulletClone;
    public GameObject shell;
    public GameObject shellClone;
    public bool readyToShoot = true;
    public float fireRate = 0.1f;
    public float coolDown= 0.1f;
    
    public void FixedUpdate()
    {
      if (readyToShoot == false)
        {
            coolDown -= 1f *Time.deltaTime;
        }
        if (coolDown <= 0)
        {
            coolDown = fireRate;
            readyToShoot = true;
        }
   
    angle = Mathf.Clamp(angle, min, max);
    gun.transform.eulerAngles = new Vector3(0, 0, angle);
    }
    
    public void zRotLeft()
    {
      angle += rotSpeed * Time.deltaTime;
    }
    public void zRotRight()
    {
      angle += -rotSpeed * Time.deltaTime;
    }
    public void zShoot()
    {
      if(readyToShoot)
      {
        shellClone = Instantiate(shell, new Vector3(transform.position.x,(transform.position.y)), transform.localRotation) as GameObject;
        bulletClone = Instantiate(bullet, new Vector3(transform.position.x,(transform.position.y)), transform.localRotation) as GameObject;
        readyToShoot = false;
        Debug.Log("shooting");
      }
      
    }
}
