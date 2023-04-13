using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Camera camsie;

    //timer
    float camCounter1;
    void Start()
    {
        beginPhaseOne();
    }

    // Update is called once per frame
    void Update()
    {
        camCounter1 -= Time.deltaTime;
        camsie.orthographicSize = Mathf.Clamp(camsie.orthographicSize, 5, 6.5f);
    }

    private void FixedUpdate()
    {
        if(camCounter1 > 0)
        {
            camsie.orthographicSize += Time.deltaTime * 1.5f;
        }
    }

    void beginPhaseOne(){
        camCounter1 = 2;
    }
}
