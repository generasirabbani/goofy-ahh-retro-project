using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthPanel : MonoBehaviour
{
    // Start is called before the first frame update
    public Image[] Bar;

    public Sprite empty;
    public Sprite fill;

    public tempPlayerHealth player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < player.currentHealth; i++)
        {
            Bar[i].sprite = fill;
        }
        for(int i = player.currentHealth; i < player.maxHealth; i++)
        {
            Bar[i].sprite = empty;
        }
    }
}
