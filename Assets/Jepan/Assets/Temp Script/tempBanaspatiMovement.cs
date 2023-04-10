using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBanaspatiMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float smoothFactor;
    public GameObject directPointer;
    Vector3 mousePos;
    public Camera cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        moveToTarget();
        dirPointer(transform.position, mousePos);
    }

    void moveToTarget()
    {
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, target.position, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothedPosition;
    }

    void dirPointer(Vector3 startPoint, Vector3 endPoint)
    {
        //var dir = startPoint - endPoint;
        //var rot = Quaternion.LookRotation(dir,Vector3.up);
        //directPointer.transform.rotation = rot;
        float rota = Mathf.Atan2((endPoint.y - startPoint.y), (endPoint.x - startPoint.x)) * Mathf.Rad2Deg;
        directPointer.transform.rotation = Quaternion.Euler(0, 0, rota);
        //if (Mathf.Abs(rota) <= 90)
        //{
        //transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        //}
        //if (Mathf.Abs(rota) >= 90)
        //{
        //transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        //}
    }
}
