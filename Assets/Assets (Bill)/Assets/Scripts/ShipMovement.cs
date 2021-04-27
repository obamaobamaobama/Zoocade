using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    private float speed;
    public int rotationSpeed;
    public int maximumTilt;
    public float fireRate;
    public bool readyToShoot;
    public float coolDown;
    public GameObject bullet;
    public GameObject bulletClone;
    public AudioSource audioSource;
    // Ethan wrote this
    public float boundaryLimit = 5f;

    void start()
    {
        readyToShoot = true;
    }
    public void FixedUpdate()
    {
        InUpdate(transform.localEulerAngles.z);
        
        if (readyToShoot == false)
        {
            coolDown -= 1f *Time.deltaTime;
        }
        if (coolDown <= 0)
        {
            coolDown = fireRate;
            readyToShoot = true;
        }
    }
    public void InUpdate(float Angle)
    {
        if(Angle > 180)
       {
           Angle -= 360;
       }
       speed = Angle / 5; //speed calculation is here

      //Debug.Log(Angle);

        if(Angle< -maximumTilt)
        {
            transform.Rotate (0 ,0, 1f); // rotate back min tilt
        }
        if(Angle >maximumTilt)
        {
            transform.Rotate (0 ,0, -1f); // rotate back to max tilt
        }
        
       transform.position = transform.position + new Vector3(0, transform.position.y, 0);
        
       if(transform.position.x >= -boundaryLimit && transform.position.x <= boundaryLimit)
            {
                transform.position = transform.position - new Vector3 (speed * Time.deltaTime, 0);
            }

        if(transform.position.x < -boundaryLimit)
        {
            transform.position = transform.position + new Vector3 (0.01f,0,0);
        }
        if(transform.position.x > boundaryLimit)
        {
            transform.position = transform.position - new Vector3 (0.01f ,0,0);
        }
    }
    public void zRotateLeft(float PlayerAngle)
    {
        transform.Rotate (0 ,0, rotationSpeed* Time.deltaTime);
    }

    public void zRotateRight(float PlayerAngle)
    {
        transform.Rotate (0 ,0, -rotationSpeed* Time.deltaTime);
    }
    
    public void zMoveLeft()
    {
        if(transform.position.x > -boundaryLimit)
        transform.position = transform.position - new Vector3 ( speed * Time.deltaTime, 0);
    }

    public void zMoveRight()
    {
        if (transform.position.x < boundaryLimit)
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0);
    }
    public void zShootBullets()
    {
        if(readyToShoot == true)
        {
            bulletClone = Instantiate(bullet, new Vector3(transform.position.x,(transform.position.y + 0.5f),0), transform.rotation) as GameObject;
            readyToShoot = false;
            audioSource.Play();
        }

    }
}
