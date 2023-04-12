using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempPlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    //public bool isDamaged;
    public bool invurnerable;
    [SerializeField] float invurnerableTime = 1f;
    public GameObject deadPanel;
    [SerializeField] float damageAnimationTime = 0.1f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if(currentHealth == 0)
        {
            dead();
        }
        animator.SetBool("isInvurnerable", invurnerable);
    }

    void damageOnPlayer()
    {
        currentHealth--;
        animator.SetTrigger("doDamaged");
        invurnerable = true;
        Invoke("exitInvurnerable", invurnerableTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy") && !invurnerable)
        {
            damageOnPlayer();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemyAttack") && !invurnerable)
        {
            damageOnPlayer();
        }
    }

    public void exitInvurnerable()
    {
        invurnerable = false;
    }

    void exitIsDamaged()
    {
        //isDamaged = false;
    }
    public void setTemporaryInvurnerable(float time)
    {
        if (!invurnerable)
        {
            invurnerable = true;
            Invoke("exitInvurnerable", time);
        }
    }
    void dead()
    {
        Destroy(gameObject);
        Time.timeScale = 0;
        deadPanel.SetActive(true);
    }
}
