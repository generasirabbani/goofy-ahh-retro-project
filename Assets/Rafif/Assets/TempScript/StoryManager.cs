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
    [SerializeField] playerDetector detector5;
    [SerializeField] playerDetector detector6;

    [Header("Canvas Object")]
    [SerializeField] GameObject text1;
    [SerializeField] GameObject text2;
    [SerializeField] GameObject text3;
    [SerializeField] GameObject text4;
    [SerializeField] GameObject text5;
    [SerializeField] GameObject text6;
    [SerializeField] GameObject text7;
    [SerializeField] GameObject text8;
    [SerializeField] GameObject text9;
    [SerializeField] GameObject story1;
    [SerializeField] GameObject story2;
    [SerializeField] GameObject story3;
    [SerializeField] GameObject finishPanel;

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
        if (detector4.playerIsHere)
        {
            text7.SetActive(true);
            StartCoroutine(deleteText(text7));
            Destroy(detector4.gameObject);
        }
        if (detector5.playerIsHere)
        {
            triggerPhase3();
        }
        if (miniBoss3Hp.isDead && !phaseThree)
        {
            finishPhase3();
        }
        if (detector6.playerIsHere)
        {
            finishStage();
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
        Destroy(text6, 3f);
        phaseTwo = true;
    }

    void triggerPhase3()
    {
        Destroy(detector5.gameObject);
        text8.SetActive(true);
        miniBoss3.SetActive(true);
        story3.SetActive(true);
        StartCoroutine(deleteText(text8));
        StartCoroutine(deleteText(story3));
    }
    void finishPhase3()
    {
        blockade3.SetActive(false);
        text9.SetActive(true);
        Destroy(text9, 3f);
        phaseThree = true;
    }

    void finishStage()
    {
        PlayerPrefs.SetInt("chapt1",1);
        finishPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private IEnumerator deleteText(GameObject text)
    {
        yield return new WaitForSeconds(3f);
        text.SetActive(false);
    }
}
