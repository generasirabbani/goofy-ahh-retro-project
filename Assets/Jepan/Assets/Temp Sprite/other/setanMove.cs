using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setanMove : MonoBehaviour
{
    // Start is called before the first frame update
    float currentX, lifecount;
    [SerializeField] float speed, lifetime;
    public bool moveToRight,moveToLeft;
    void Start()
    {
        currentX = transform.position.x;
        lifecount = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(currentX, transform.position.y, transform.position.z);
        lifecount -= Time.deltaTime;
        move();
        if (lifecount <= 0)
        {
            Destroy(gameObject);
        }
    }

    void move()
    {
        if (moveToRight)
        {
            currentX += speed * Time.deltaTime;
        }
        else if (moveToLeft)
        {
            currentX -= speed * Time.deltaTime;
        }
    }
}
