using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    float transition1 = 0.25f, transition2 = 1f;
    float transitionCount1 = 0, transitionCount2 = 0;
    [SerializeField] float showTime, hideTime;
    float currentY;
    float maxY;
    void Start()
    {
        maxY = transform.position.y;
        currentY = transform.position.y;
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        currentY = Mathf.Clamp(currentY,maxY - 1,maxY);
        transitionCount1 -= Time.deltaTime;
        transitionCount2 -= Time.deltaTime;
        transform.position = new Vector3(transform.position.x, currentY, transform.position.z);
        if(transitionCount1 > 0)
        {
            currentY += Time.deltaTime * 6f;
        }
        if(transitionCount2 > 0)
        {
            currentY -= Time.deltaTime * 1.5f;
        }
    }

    void appearOnGround()
    {
        transitionCount1 = transition1;
        Invoke("stayOnGround", transition1 + 0.25f);
    }

    void stayOnGround()
    {
        Invoke("hide", showTime);
    }

    void hide()
    {
        transitionCount2 = transition2;
        Invoke("stayOnHide", transition2 + 0.25f);
    }

    void stayOnHide()
    {
        Invoke("appearOnGround", hideTime);
    }

}
