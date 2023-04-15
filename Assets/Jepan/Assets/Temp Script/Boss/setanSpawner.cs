using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setanSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform spot1,spot2, spot3, spot4;
    [SerializeField] float delayTime;
    [SerializeField] GameObject setan1, setan2;
    public bool isSpawning;
    void Start()
    {
        //startSpawnSetan();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startSpawnSetan()
    {
        int lucky = Mathf.FloorToInt(Random.Range(0, 3));
        if(lucky == 0)
        {
            GameObject obj = Instantiate(setan1, spot1);
            obj.transform.position = spot1.position;
        }
        else if(lucky == 1)
        {
            GameObject obj = Instantiate(setan1, spot2);
            obj.transform.position = spot2.position;
        }
        else if(lucky == 2)
        {
            GameObject obj = Instantiate(setan2 , spot3);
            obj.transform.position = spot3.position;
        }
        else if(lucky >= 3)
        {
            GameObject obj = Instantiate(setan2,spot4);
            obj.transform.position = spot4.position;
        }
        Invoke("waitForSpawn", delayTime);
    }

    void waitForSpawn()
    {
        if (isSpawning)
        {
            Invoke("startSpawnSetan", delayTime);
        }
        else
        {
            Invoke("waitForSpawn", delayTime);
        }
    }
}
