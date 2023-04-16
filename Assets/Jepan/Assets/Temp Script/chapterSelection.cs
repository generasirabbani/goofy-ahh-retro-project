using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chapterSelection : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int[] chapter;
    [SerializeField] Button[] chapterButton;
    void Start()
    {
        foreach(var Button in chapterButton)
        {
            Button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        chapter[0] = PlayerPrefs.GetInt("tutorial");
        chapter[1] = PlayerPrefs.GetInt("chapt1");
        chapter[2] = PlayerPrefs.GetInt("chapt2");
        chapter[3] = PlayerPrefs.GetInt("chapt3");
        onDisplayingButton();
    }

    void onDisplayingButton()
    {
        chapterButton[0].interactable = true;
        for (int i = 0; i < chapterButton.Length-1; i++)
        {
            if(chapter[i] > 0)
            {
                chapterButton[i + 1].interactable = true;
            }
            else if(chapter[i] == 0)
            {
                chapterButton[i + 1].interactable = false;
            }
        }
    }
}
