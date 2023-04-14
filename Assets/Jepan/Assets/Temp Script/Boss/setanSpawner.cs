using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setanSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform spot1,spot2, spot3, spot4;
    [SerializeField] float delayTime;
    [SerializeField] GameObject setan1, setan2;
    void Start()
    {
        startSpawnSetan();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void startSpawnSetan()
    {
        int lucky = Mathf.FloorToInt(Random.Range(0, 3));
        if(lucky == 0)
        {
            Instantiate(setan1, spot1);
        }
        else if(lucky == 1)
        {
            Instantiate(setan1, spot2);
        }
        else if(lucky == 2)
        {
            Instantiate(setan2 , spot3);
        }
        else if(lucky >= 3)
        {
            Instantiate(setan2,spot4);
        }
        Invoke("startSpawnSetan", delayTime);
    }
}
