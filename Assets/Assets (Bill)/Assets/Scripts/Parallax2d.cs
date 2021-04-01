using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2d : MonoBehaviour
{
    public float parallaxEffect = 0.5f;
    private Transform cameraTransform;
    private Vector3 lastCameraPos;
    private float textureUnitSizeX;
       void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPos = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeX = texture.width / sprite.pixelsPerUnit; //calculate size of the BG sprite
    }

    void LateUpdate()
    {
        Vector3 camMovement = cameraTransform.position - lastCameraPos;
        
        transform.position += camMovement * parallaxEffect;
        lastCameraPos = cameraTransform.position;

        if(Mathf.Abs (cameraTransform.position.x - transform.position.x) >= textureUnitSizeX) //if the camera position minus sprite's position is bigger / equal to texture size
        {
            float offsetPosX = (cameraTransform.position.x - transform.position.x) % textureUnitSizeX; //getting the remainder of the position based of texture size
            transform.position = new Vector3(cameraTransform.position.x + offsetPosX, transform.position.y);
        }
    }
}
