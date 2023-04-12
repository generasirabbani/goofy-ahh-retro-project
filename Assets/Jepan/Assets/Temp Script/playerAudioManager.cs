using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource sfx1;
    public AudioSource sfx2;
    public AudioSource sfx3;
    public AudioSource sfx4;
    public AudioSource sfx5;
    public AudioSource sfx6;

    public AudioClip walk1;
    public AudioClip walk2;
    public AudioClip jump;
    public AudioClip dash;
    public AudioClip land;
    public AudioClip dmg;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void walkOne()
    {
        sfx1.PlayOneShot(walk1);
    }
    public void walkTwo()
    {
        sfx1.PlayOneShot(walk2);
    }

    public void jumpSFX()
    {
        sfx2.PlayOneShot(jump);
    }
    public void landSFX()
    {
        sfx3.PlayOneShot(land);
    }

    public void dashSFX()
    {
        sfx4.PlayOneShot(dash);
    }

    public void damaged()
    {
        sfx5.PlayOneShot(dmg);
    }

    public void wallslidSFX()
    {
        sfx6.PlayOneShot(walk2);
    }
}
