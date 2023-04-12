using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float bulletLifeTime = 0.75f;
    public float deadTime = 0.5f;
    Animator anim;
    Rigidbody2D rb;
    ParticleSystem ps;
    float lifetime = 0;
    public AudioClip boom;
    AudioSource audios;
    void Start()
    {
        audios = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        ps = GetComponent<ParticleSystem>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        lifetime += Time.deltaTime;
        if(lifetime > bulletLifeTime)
        {
            Destroy(gameObject);
        }
    }

    void onDamaging()
    {
        lifetime = 0;
        //rb.velocity = Vector3.zero;
        rb.bodyType = RigidbodyType2D.Static;
        Destroy(gameObject, deadTime);
        anim.SetTrigger("Destroy");
        audios.PlayOneShot(boom);
        ps.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("enemy"))
        {
            onDamaging();
        }
    }
}
