using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("PlayerDetector")]
    [SerializeField] playerDetector move;
    [SerializeField] playerDetector jump;
    [SerializeField] playerDetector dash;
    [SerializeField] playerDetector walljump;
    [SerializeField] playerDetector shoot;
    [SerializeField] playerDetector finishTrigger;

    [Header("Canvas Object")]
    [SerializeField] GameObject moveText;
    [SerializeField] GameObject jumpText;
    [SerializeField] GameObject dashText;
    [SerializeField] GameObject walljumpText;
    [SerializeField] GameObject shootText;
    [SerializeField] GameObject finishPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move.playerIsHere)
        {
            moveText.SetActive(true);
        }
        else
        {
            moveText.SetActive(false);
        }

        if(jump.playerIsHere)
        {
            jumpText.SetActive(true);
        }
        else
        {
            jumpText.SetActive(false);
        }

        if (dash.playerIsHere)
        {
            dashText.SetActive(true);
        }
        else
        {
            dashText.SetActive(false);
        }

        if (walljump.playerIsHere)
        {
            walljumpText.SetActive(true);
        }
        else
        {
            walljumpText.SetActive(false);
        }

        if(shoot.playerIsHere)
        {
            shootText.SetActive(true);
        }
        else
        {
            shootText.SetActive(false);
        }

        if (finishTrigger.playerIsHere)
        {
            finishTutorial();
        }

    }
    void finishTutorial()
    {
        PlayerPrefs.SetInt("tutorial", 1);
        Time.timeScale = 0;
        finishPanel.SetActive(true);
    }
}
