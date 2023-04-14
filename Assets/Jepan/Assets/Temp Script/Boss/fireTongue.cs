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
    void Start()
    {
        currentXpos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        doAttack();
        transform.position = new Vector3 (currentXpos, transform.position.y, transform.position.z);
    }

    void doAttack()
    {
        if (transform.position.x <= minX)
        {
            right();
        }
        else
        {
            left();
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
