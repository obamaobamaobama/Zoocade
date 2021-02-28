using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIndicator : MonoBehaviour
{
  public Transform target;
 
  void Start()
  {
    var visual = GetComponent<SpriteRenderer>();
  }
    void FixedUpdate()
    {
        var visual = GetComponent<SpriteRenderer>();
        transform.position = new Vector3(target.position.x, transform.position.y,0);
        if(target.position.y < transform.position.y - 0.5f)
        {
            visual.enabled = true;
        }
        else
        {
            visual.enabled = false;
        }
    }


}
