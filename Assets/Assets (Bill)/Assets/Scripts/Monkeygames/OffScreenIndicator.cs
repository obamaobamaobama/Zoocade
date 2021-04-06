using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffScreenIndicator : MonoBehaviour
{
    public GameObject Indicator;
    public Transform IndicatorTransform;
    public Renderer rd;
     private Transform cameraTransform;
     private RaycastHit2D ray;
    void Start()
    {
        rd = this.GetComponent<SpriteRenderer>();
        cameraTransform = Camera.main.transform;
        rd.enabled = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(rd.isVisible == false)
        {
            if(Indicator.activeSelf == false)
            {
                Indicator.SetActive(true);
            }
        }
        else
        {
           Indicator.SetActive(false);
        }
        
    }
       void LateUpdate()
    {
        ray = Physics2D.Raycast( new Vector3(transform.position.x ,15), Vector2.left); //this is a cheesy way to do this, checking raycast on top of the screen. But it works
        Debug.DrawRay(new Vector3(transform.position.x ,15), Vector2.left);

            //if(ray.collider.tag =="bounds" && rd.isVisible == false)
            if(rd.isVisible == false)
            {
                IndicatorTransform.position = new Vector3(ray.point.x, transform.position.y); 
            }
    }

}
