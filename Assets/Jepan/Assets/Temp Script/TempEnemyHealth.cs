using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempEnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 3;
    public int currentHealth;
    //public bool isDamaged;
    public bool invurnerable;
    //public GameObject deadPanel;
    [SerializeField] float invurnerableTime = 0f;
    [SerializeField] float damageAnimationTime = 0.1f;
    Animator animator;
    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth == 0)
        {
            dead();
        }
    }

    void damageOnPlayer()
    {
        currentHealth--;
        animator.SetTrigger("doDamaged");
        //invurnerable = true;
        //Invoke("exitInvurnerable", invurnerableTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") && !invurnerable)
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

    

    void dead()
    {
        Destroy(gameObject, 0.25f);
        //deadPanel.SetActive(true);
    }
}
