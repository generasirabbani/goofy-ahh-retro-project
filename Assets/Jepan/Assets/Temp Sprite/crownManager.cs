using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crownManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject crown;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerPrefs.GetInt("king",0) > 1)
        {
            crown.SetActive(true);
        }
        else
        {
            crown.SetActive(false);
        }
    }
}
