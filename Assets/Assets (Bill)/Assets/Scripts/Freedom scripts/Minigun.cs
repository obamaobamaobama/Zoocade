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
    
    public Transform muzzlePosR;
    public Transform shellLaunchR;
    public Transform muzzlePosL;
    public Transform shellLaunchL;
    public SpriteRenderer body;
    public SpriteRenderer feet;
    private bool flipped = false;
    public Animator ani;

    public AudioSource speaker;

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
    public void Update()
    {
      if(transform.rotation.z < 0)
      {
        body.flipX = false;
        feet.flipX = false;
         body.flipY = false;
        feet.flipY = false;
        flipped = false;
      }
      if(transform.rotation.z > 0)
      {
       
        feet.flipX = true;
        body.flipY = true;
        flipped = true;
        
      }
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
        if(!flipped)
        {
          shellClone = Instantiate(shell, new Vector3(shellLaunchR.position.x,(shellLaunchR.position.y)), transform.localRotation) as GameObject;
          bulletClone = Instantiate(bullet, new Vector3(muzzlePosR.position.x,(muzzlePosR.position.y)), transform.localRotation) as GameObject;
          readyToShoot = false;
          ani.Play("Gun fire");
          speaker.Play();
        }
        else //flipped, different locations for muzzle
        {
          shellClone = Instantiate(shell, new Vector3(shellLaunchL.position.x,(shellLaunchL.position.y)), transform.localRotation) as GameObject;
          bulletClone = Instantiate(bullet, new Vector3(muzzlePosL.position.x,(muzzlePosL.position.y)), transform.localRotation) as GameObject;
          readyToShoot = false;
          ani.Play("Gun fire");
          speaker.Play();
        }
      }
      
    }
}
