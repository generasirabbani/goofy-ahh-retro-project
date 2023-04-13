using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follows3 : MonoBehaviour
{
    [SerializeField] float smoothFactor;
    [SerializeField] Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void moveToTarget()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }
}
