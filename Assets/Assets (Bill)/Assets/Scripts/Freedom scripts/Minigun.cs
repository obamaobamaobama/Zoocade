using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minigun : MonoBehaviour
{
    public float rotSpeed;
    public float fireRate = 0.5f;
    public GameObject projectile;
    public GameObject projectileClone;
    public GameObject gun;
    public float angle;
    public float min;
    public float max;
    
    public void FixedUpdate()
    {
    
   
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

    }
}
