using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMove : MonoBehaviour
{
    // Start is called before the first frame update
    float currentY, lifecount;
    [SerializeField] float speed,lifetime;
    void Start()
    {
        currentY = transform.position.y;
        lifecount = lifetime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        lifecount -= Time.deltaTime;
        move();
        if(lifecount <= 0)
        {
            Destroy(gameObject);
        }
    }

    void move()
    {
        currentY -= speed * Time.deltaTime;
    }
}
