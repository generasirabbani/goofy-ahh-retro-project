using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject platform;
    public float perSpawnTime;
    public Vector2 chances;
    void Start()
    {
        Invoke("spawnPlatform", perSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPlatform()
    {
        int luck = Mathf.FloorToInt(Random.Range(0, chances.y));
        if(luck <= chances.x)
        {
            Instantiate(platform,transform);
        }
        Invoke("spawnPlatform", perSpawnTime);
    }
}
