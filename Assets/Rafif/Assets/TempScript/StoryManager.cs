using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [Header("Player Detector")]
    [SerializeField] playerDetector detector1;
    [SerializeField] playerDetector detector2;
    [SerializeField] playerDetector detector3;
    [SerializeField] playerDetector detector4;

    [Header("Canvas Object")]
    [SerializeField] GameObject story1;
    [SerializeField] GameObject story2;
    [SerializeField] GameObject story3;
    [SerializeField] GameObject story4;

    [Header("Spawner")]
    [SerializeField] GameObject miniBoss;
    [SerializeField] GameObject spawner1;
    [SerializeField] GameObject spawner2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
