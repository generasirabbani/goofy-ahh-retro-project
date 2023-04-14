using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallScript : MonoBehaviour
{
    // Start is called before the first frame update
    float lifetime = 0;
    [SerializeField] float targetLifeTime = 2f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if (lifetime > targetLifeTime)
        {
            Destroy(gameObject);
        }
    }
}
