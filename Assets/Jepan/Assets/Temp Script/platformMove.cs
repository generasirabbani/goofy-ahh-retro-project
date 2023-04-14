using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    // Start is called before the first frame update
    float currentY, lifecount;
    [SerializeField] float speed,lifetime;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //currentY = transform.position.y;
        lifecount = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        lifecount -= Time.deltaTime;
        move();
        if(lifecount <= 0)
        {
            Destroy(gameObject);
        }
    }

    void move()
    {
        rb.velocity = new Vector2(0,-speed);
        //currentY -= speed * Time.deltaTime;
    }
}
