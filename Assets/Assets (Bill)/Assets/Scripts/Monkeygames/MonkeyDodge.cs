using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyDodge : MonoBehaviour
{
    public Collider2D standCol;
    public Collider2D crouchCol;
    public Animator ani;
    private bool isCrouching;
    public float jumpForce;
    public float vsp;
    public float gravity;
    public bool grounded;
    public float whereIsGroundY;

    //Audio here
    public AudioSource playerAudio;
    public AudioClip jump;

    public void FixedUpdate()
    {
        if(isCrouching)
        {
            standCol.enabled = false;
            crouchCol.enabled = true;
            ani.Play("Monkey crouch");
        }
        else
        {
            standCol.enabled = true;
            crouchCol.enabled = false;
            ani.Play("Monkey idle");
        }
          transform.position += new Vector3(0,vsp);

        if(transform.position.y > whereIsGroundY)
        {
            vsp-=gravity * Time.deltaTime;
        }
        else
        {
            grounded = true;
            transform.position = new Vector3(transform.position.x, whereIsGroundY);
        }
    }
    public void zEnterCrouch() // in hold
    {
        if(grounded)
        {
            isCrouching = true;
        }
        
    }
    public void zExitCrouch() // in button up
    {
        isCrouching = false;
    }

    public void zJump()
    {
         if(grounded && !isCrouching)
        {
            playerAudio.clip= jump;
            playerAudio.Play();

            vsp = 0;
            vsp += jumpForce;
            grounded = false;
        }
    }
}
