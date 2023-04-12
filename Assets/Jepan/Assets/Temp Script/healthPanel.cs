using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Image Bar1;
    public Image Bar2;
    public Image Bar3;

    public Sprite empty;
    public Sprite fill;

    public tempPlayerHealth player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.currentHealth == 3)
        {
            Bar1.sprite = fill;
            Bar2.sprite = fill;
            Bar3.sprite = fill;
        }
        if (player.currentHealth == 2)
        {
            Bar1.sprite = fill;
            Bar2.sprite = fill;
            Bar3.sprite = empty;
        }
        if (player.currentHealth == 1)
        {
            Bar1.sprite = fill;
            Bar2.sprite = empty;
            Bar3.sprite = empty;
        }
        if(player.currentHealth == 0)
        {
            Bar1.sprite = empty;
            Bar2.sprite = empty;
            Bar3.sprite = empty;
        }
    }
}
