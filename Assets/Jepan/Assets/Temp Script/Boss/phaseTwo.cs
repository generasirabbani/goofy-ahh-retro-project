using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseTwo : MonoBehaviour
{
    [Header("Attack")]
    [SerializeField] fireBallAttack fireballAtk;
    [SerializeField] GameObject tongueAtk;
    [SerializeField] GameObject jailangkungSpawner;

    [Header("attack Val")]
    [SerializeField] float fireBallAtkTime;
    [SerializeField] float jailangkungAtkTime;
    //[SerializeField] GameObject setanSpawner;

    float riseCount;
    [SerializeField] float riseTime;
    [SerializeField] float currentYPos;
    [SerializeField] float attackTimeDelay;
    [SerializeField] GameObject body;
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
       float atkIndex = Mathf.FloorToInt(Random.Range(0, 2));
       if (atkIndex == 0)
        {
            Invoke("doSpawnAtk", attackTimeDelay);
        }
       else if (atkIndex >= 1)
        {
            Invoke("doFireBallAtk", attackTimeDelay);
        }
    }

    void doSpawnAtk()
    {
        jailangkungSpawner.SetActive(true);
        Invoke("turnOffSpawnAtk", jailangkungAtkTime);
    }

    void turnOffSpawnAtk()
    {
        jailangkungSpawner.SetActive(false);
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
}
