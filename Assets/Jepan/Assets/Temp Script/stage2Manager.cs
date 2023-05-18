using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stage2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public WaveSpawner waveSpawner;
    [SerializeField] playerDetector[] playerDetector;
    [SerializeField] GameObject[] text;
    [SerializeField] GameObject[] canvasObjects;
    [SerializeField] GameObject[] blockade;
    public Camera camsie;
    float camCounter1;
    bool finished;
    [SerializeField] menuManager menu;
    void Start()
    {
        Time.timeScale = 1;
        text[0].SetActive(true);
        StartCoroutine(deleteText(0, 3));
        
    }

    // Update is called once per frame
    void Update()
    {
        camCounter1 -= Time.deltaTime;
        camsie.orthographicSize = Mathf.Clamp(camsie.orthographicSize, 5, 8f);

        if (playerDetector[0].playerIsHere)
        {
            startStage2();
        }
        if (waveSpawner.allWaveCompleted)
        {
            endStage2();
        }
        if(finished && playerDetector[1].playerIsHere)
        {
            finish();
        }
    }

    private void FixedUpdate()
    {
        if(camCounter1 > 0)
        {
            camsie.orthographicSize += Time.deltaTime * 1.5f;
        }
    }

    void startStage2()
    {
        playerDetector[0].gameObject.SetActive(false);
        blockade[0].SetActive(true);
        text[0].SetActive(false);
        text[1].SetActive(true);
        text[2].SetActive(true);
        StartCoroutine(deleteText(1, 3));
        StartCoroutine(deleteText(2, 5));
        camCounter1 = 3f;
        waveSpawner.gameObject.SetActive(true);
    }

    void endStage2()
    {
        waveSpawner.gameObject.SetActive(false);
        text[3].SetActive(true);
        blockade[1].SetActive(false);
        finished = true;
    }

    private IEnumerator deleteText(int index,float time)
    {
        yield return new WaitForSeconds(time);
        text[index].SetActive(false);
    }

    void finish()
    {
        menu.isFinished = true;
        PlayerPrefs.SetInt("chapt2", 1);
        canvasObjects[1].SetActive(true);
        Time.timeScale = 0;
    }
}
