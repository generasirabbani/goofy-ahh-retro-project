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
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject text5;
    [SerializeField] GameObject text6;
    [SerializeField] GameObject text7;
    [SerializeField] GameObject text8;
    [SerializeField] GameObject story1;
    [SerializeField] GameObject story2;
    [SerializeField] GameObject story3;

    [Header("Spawner")]
    [SerializeField] GameObject miniBoss1;
    [SerializeField] GameObject miniBoss2;
    [SerializeField] GameObject miniBoss3;

    [Header("HP-Counter")]
    [SerializeField] TempEnemyHealth miniBoss1Hp;
    [SerializeField] TempEnemyHealth miniBoss2Hp;
    [SerializeField] TempEnemyHealth miniBoss3Hp;

    [Header("Blockade")]
    [SerializeField] GameObject blockade1;
    [SerializeField] GameObject blockade2;
    [SerializeField] GameObject blockade3;

    [Header("Phase finish")]
    [SerializeField] bool phaseOne;
    [SerializeField] bool phaseTwo;
    [SerializeField] bool phaseThree;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        text1.SetActive(true);
        StartCoroutine(deleteText(text1));
    }

    // Update is called once per frame
    void Update()
    {
        if (detector1.playerIsHere)
        {
            text1.SetActive(false);
            triggerPhase1();
        }
        if (miniBoss1Hp.isDead && !phaseOne)
        {
            finishPhase1();
        }
        if (detector2.playerIsHere)
        {
            text4.SetActive(true);
            StartCoroutine(deleteText(text4));
            Destroy(detector2.gameObject);
        }
        if (detector3.playerIsHere)
        {
            triggerPhase2();
        }
        if (miniBoss2Hp.isDead && !phaseTwo)
        {
            finishPhase2();
        }
    }

    private void FixedUpdate()
    {
        
    }

    void triggerPhase1()
    {
        Destroy(detector1.gameObject);
        text2.SetActive(true);
        miniBoss1.SetActive(true);
        story1.SetActive(true);
        StartCoroutine(deleteText(text2));
        StartCoroutine(deleteText(story1));
    }

    void finishPhase1()
    {
        blockade1.SetActive(false);
        text3.SetActive(true);
        Destroy(text3, 3f);
        phaseOne = true;
    }

    void triggerPhase2()
    {
        Destroy(detector3.gameObject);
        text5.SetActive(true);
        miniBoss2.SetActive(true);
        story2.SetActive(true);
        StartCoroutine(deleteText(text5));
        StartCoroutine(deleteText(story2));
    }
    void finishPhase2()
    {
        blockade2.SetActive(false);
        text6.SetActive(true);
        Destroy(text3, 3f);
        phaseTwo = true;
    }
    private IEnumerator deleteText(GameObject text)
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
