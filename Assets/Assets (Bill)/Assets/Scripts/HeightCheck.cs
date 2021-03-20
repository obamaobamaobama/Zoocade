using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeightCheck : MonoBehaviour
{
    public Text heightDisplay;
    public Vector2 raycastDirection;
    public float speed;
    public string player1or2;
    public float upCheckDistance = 0.5f;

    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(raycastDirection),15f);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector2.left)* 15f,Color.red);

        if(hit && transform.position.y >-4)
        {
            //Check if we're at the top
            if (CheckIfNotTop())
            {
                //We only move upwards again if CheckIfNotTop returns true
                transform.position = transform.position + new Vector3(0, speed * Time.deltaTime);
            }            
        }
        else if (transform.position.y >-4)
        {
           transform.position = transform.position - new Vector3(0,speed * Time.deltaTime);
        }
        if(transform.position.y < -4)
        {
            transform.position = transform.position + new Vector3(0,0.1f * Time.deltaTime);
        }
    }
    void Update()
    {
        float localY = transform.position.y + 4f;
        heightDisplay.text = player1or2 + (Mathf.Round(localY * 10) /10);
    }

    //Draw a raycast above the current position and return a boolean - True = not at the top, False = at the top
    private bool CheckIfNotTop()
    {
        Vector3 upCheck = transform.position;
        upCheck.y += upCheckDistance;
        RaycastHit2D notTop = Physics2D.Raycast(upCheck, transform.TransformDirection(raycastDirection), 15f);

        return notTop;
    }
}
