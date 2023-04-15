using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRXBGVer2xd : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Vector2 parallaxEffectMultiplier;
    [SerializeField] bool infiniteHorizontal;
    [SerializeField] bool infiniteVertical;
    [SerializeField] Transform cameraTransform;
    private Vector3 lastCameraPosition;
    private float texture_unit_size_x_;
    private float texture_unit_size_y_;
    

    void Start()
    {
        
        lastCameraPosition = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        texture_unit_size_x_ = (texture.width / sprite.pixelsPerUnit) * transform.localScale.x;
        texture_unit_size_y_ = (texture.height / sprite.pixelsPerUnit) * transform.localScale.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y);
        lastCameraPosition = cameraTransform.position;
        if (infiniteHorizontal)
        {
            if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= texture_unit_size_x_)
            {
                float offsetPositionX = (cameraTransform.position.x - transform.position.x) % texture_unit_size_x_;
                transform.position = new Vector3(cameraTransform.position.x + offsetPositionX, transform.position.y);

            }
        }
        if (infiniteVertical)
        {
            if (Mathf.Abs(cameraTransform.position.y - transform.position.y) >= texture_unit_size_y_)
            {
                float offsetPositionY = (cameraTransform.position.y - transform.position.y) % texture_unit_size_y_;
                transform.position = new Vector3(transform.position.x, cameraTransform.position.y + offsetPositionY);

            }
        }
        
    }

}
