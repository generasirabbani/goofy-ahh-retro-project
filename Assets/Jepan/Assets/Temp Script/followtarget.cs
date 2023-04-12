using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followtarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D target;
    Rigidbody2D chaser;
    void Start()
    {
        chaser = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        follow();
    }

    void follow()
    {
        chaser.velocity = target.velocity;
    }
}
