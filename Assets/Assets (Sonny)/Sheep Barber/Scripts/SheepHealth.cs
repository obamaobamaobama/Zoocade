using UnityEngine;
using UnityEngine.Events;

//This script component will give health behavior to any object it is applied to. 
//Use the inspector to set the object starting health. 
//Call the TakeDamage function to take damage from the health.
//When the object dies it will call the objectHasDied Event.
//Use the inspector to have this event call other function on other scripts. 

public class SheepHealth : MonoBehaviour
{
    public int health;

    private Animator _anim;

    public bool HairCut = false;

    public Collider2D hairTriggerZone;

    private void Awake()
    {
        _anim = this.GetComponent<Animator>();
        hairTriggerZone.enabled = true;
    }

    // void CutHair(GameObject _collision)
    //{
    //    _anim.SetBool("Hit", true);
   // }

    public void TakeDamage(int DamageToTake)
    {
        var TM = GameObject.Find("TimeManager").GetComponent<TimeManager>();

        health -= DamageToTake;

        if (health <= 750)
        {
            _anim.SetBool("75", true);
        }

        if (health <= 500)
        {
            _anim.SetBool("50", true);
        }

        if (health <= 250)
        {
            _anim.SetBool("25", true);
        }

        if (health <= 0)
        {
            _anim.SetBool("Cut", true);

            HairCut = true;

            AudioSource.PlayClipAtPoint(this.GetComponent<AudioSource>().clip, Camera.main.transform.position);

            GameObject.Find("Control_Manager").GetComponent<ControlManager>().enabled = false;
            if (this.gameObject.name == "Sheep_Afro P1") { TM.zP1Done(); TM.zP1Wins(); }
            if (this.gameObject.name == "Sheep_Afro P2") { TM.zP2Done(); TM.zP2Wins(); }

        }
    }

}

