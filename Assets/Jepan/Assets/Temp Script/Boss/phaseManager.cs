using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class phaseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public Camera camsie;
    public menuManager menu;

    [Header("needed Detector")]
    [SerializeField] playerDetector txt1;
    [SerializeField] playerDetector txt2;
    [SerializeField] playerDetector txt3;

    [Header("Bosses")]
    [SerializeField] GameObject phaseOne;
    [SerializeField] phaseTwo phase2;

    [Header("needed collider")]
    [SerializeField] GameObject blockade;


    [Header("needed Canvas Object")]
    [SerializeField] GameObject txt1text;
    [SerializeField] GameObject txt2text;
    [SerializeField] GameObject txt3text;
    [SerializeField] GameObject txt4text;
    [SerializeField] GameObject finishPanel;

    [Header("Other")]
    [SerializeField] Tilemap BG;
    [SerializeField] AudioSource musika;
    [SerializeField] AudioClip phaseTwoClip;
    [SerializeField] GameObject oldGround, newGround;
    [SerializeField] GameObject platformSpawnerz;
    [SerializeField] AstarPath path;

    //timer
    float camCounter1;
    void Start()
    {
        //beginPhaseOne();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        camCounter1 -= Time.deltaTime;
        camsie.orthographicSize = Mathf.Clamp(camsie.orthographicSize, 5, 6.5f);

        if (txt1.playerIsHere)
        {
            preDialogueOne();
        }

        if (txt2.playerIsHere)
        {
            preDialogueTwo();
        }

        if (txt3.playerIsHere)
        {
            beginPhaseOne();
        }
    }

    private void FixedUpdate()
    {
        if(camCounter1 > 0)
        {
            camsie.orthographicSize += Time.deltaTime * 1.5f;
        }
    }

    void preDialogueOne()
    {
        txt1text.SetActive(true);
        txt1.gameObject.SetActive(false);
        Invoke("deleteDialogueOne", 3f);
    }

    void deleteDialogueOne()
    {
        txt1text.SetActive(false);
    }

    void preDialogueTwo()
    {
        txt1text.SetActive(false);
        txt2text.SetActive(true);
        txt2.gameObject.SetActive(false);
        Invoke("deleteDialogueTwo", 3f);
    }

    void deleteDialogueTwo()
    {
        txt2text.SetActive(false);
    }

    void beginPhaseOne()
    {
        txt3.gameObject.SetActive(false);
        txt1text.SetActive(false);
        txt2text.SetActive(false);
        phaseOne.SetActive(true);
        txt3text.SetActive(true);
        blockade.SetActive(true);
        camCounter1 = 2;
        Invoke("deleteDialogueThree", 3f);
    }
    
    void deleteDialogueThree()
    {
        txt3text.SetActive(false);
    }

    public void prePhaseTwo()
    {
        platformSpawnerz.SetActive(true);
        txt4text.SetActive(true);
        Invoke("deleteDialogueFour", 3f);
        setBGColorPhaseTwo();
        musika.Stop();
        musika.clip = phaseTwoClip;
        musika.Play();
        newGround.SetActive(true);
        oldGround.SetActive(false);
        Invoke("startphs2",2f);
        path.Scan();
    }


    void startphs2()
    {
        phase2.startPhaseTwo();
    }
    void setBGColorPhaseTwo()
    {
        BG.color = new Color(255,0,0,255);
    }

    void deleteDialogueFour()
    {
        txt4text.SetActive(false);
    }

    public void finish()
    {
        menu.isFinished = true;   
        finishPanel.SetActive(true);
        PlayerPrefs.SetInt("chapt3", 1);
        if(PlayerPrefs.GetInt("cheated",0) == 0)
        {
            PlayerPrefs.SetInt("king", 1);
        }
        Time.timeScale = 0;
    }
}
