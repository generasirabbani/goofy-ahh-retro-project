using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseTwo : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] fireBallAttack fireballAtk;
    [SerializeField] GameObject tongueAtk;
    [SerializeField] setanSpawner jailangkungSpawner;
    [SerializeField] setanSpawner jelangkungSpawner;

    [Header("attack Val")]
    [SerializeField] float fireBallAtkTime;
    [SerializeField] float jailangkungAtkTime;
    [SerializeField] float jelangkungAtkTime;
    //[SerializeField] GameObject setanSpawner;

    float riseCount;
    [SerializeField] float riseTime;
    [SerializeField] float currentYPos;
    [SerializeField] float attackTimeDelay;
    [SerializeField] GameObject body;
    [SerializeField] TempEnemyHealth HP;
    [SerializeField] phaseManager phaseManager;
    public bool isDead;
    //[SerializeField] Animator anim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentYPos = Mathf.Clamp(currentYPos, -35, 0);
        riseCount -= Time.deltaTime;
        if(riseCount > 0)
        {
            currentYPos += Time.deltaTime * 2;
        }
        transform.position = new Vector3(transform.position.x, currentYPos, transform.position.z);
    }

    public void Raise()
    {
        riseCount = riseTime;
    }

    public void startAtk()
    {
        tongueAtk.SetActive(true);
        attackRandomizer();
    }

    void attackRandomizer()
    {
        float maxRange;
        if(HP.currentHealth > HP.maxHealth / 2)
        {
            maxRange = 2f;
        }
        else
        {
            maxRange = 3f;
            attackTimeDelay = 0f;
        }
       float atkIndex = Mathf.FloorToInt(Random.Range(0, maxRange));
        if(HP.currentHealth <= 0 || HP.isDead)
        {
            isDead = true;
            phaseManager.finish();
            return;
        }
       else if (atkIndex == 0)
        {
            Invoke("doSpawnAtk", attackTimeDelay);
        }
       else if (atkIndex >= 1 && atkIndex <= 2f)
        {
            Invoke("doFireBallAtk", attackTimeDelay);
        }
        else if (atkIndex > 2)
        {
            Invoke("doJelangkungSpawn", attackTimeDelay);
        }
    }

    void doSpawnAtk()
    {
        jailangkungSpawner.isSpawning = true;
        Invoke("turnOffSpawnAtk", jailangkungAtkTime);
    }

    void turnOffSpawnAtk()
    {
        jailangkungSpawner.isSpawning = false;
        Invoke("attackRandomizer",attackTimeDelay);
    }

    void doFireBallAtk()
    {
        fireballAtk.doFireBallAttack();
        Invoke("attackRandomizer", fireBallAtkTime);
    }
    
    public void startPhaseTwo()
    {
        Raise();
        body.SetActive(true);
        Invoke("startAtk",riseTime);
    }

    void turnOn()
    {
        
    }

    void doJelangkungSpawn()
    {
        jailangkungSpawner.isSpawning = true;
        Invoke("doTurnOffJelangkungSpawn", jelangkungAtkTime);
    }

    void doTurnOffJelangkungSpawn()
    {
        jelangkungSpawner.isSpawning = false;
        Invoke("attackRandomizer", attackTimeDelay);
    }
    
}
