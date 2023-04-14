using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireTongue : MonoBehaviour
{
    // Start is called before the first frame update
    float currentXpos;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    [SerializeField] float speed;
    bool isMovingLeft,isMovingRight;
    void Start()
    {
        currentXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        doAttack();
        transform.position = new Vector3 (currentXpos, transform.position.y, transform.position.z);
        if (isMovingRight)
        {
            right();
        }
        if (isMovingLeft)
        {
            left();
        }
    }

    void doAttack()
    {
        if (transform.position.x <= minX)
        {
            isMovingLeft = false;
            isMovingRight = true;
        }
        else if (transform.position.x >= maxX)
        {
            isMovingRight = false;
            isMovingLeft=true;
        }
    }

    void right()
    {
        currentXpos += speed * Time.deltaTime;
    }

    void left()
    {
        currentXpos -= speed * Time.deltaTime;
    }
}
