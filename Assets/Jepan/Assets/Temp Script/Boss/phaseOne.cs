using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseOne : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("attackScript")]
    [SerializeField] TongueAttack tongueAtk;
    [SerializeField] Animator handAtk;
    [SerializeField] fireBallAttack fireballAtk;


    [Header("attack Addons")]
    [SerializeField] GameObject tongueAtkIndicator;

    [Header("value")]
    [SerializeField] float attackTimeDelay = 5f;
    [SerializeField] float tongueAtkTime = 15f;
    [SerializeField] float handAtkTime = 15f;
    [SerializeField] float fireballAtkTime = 8f;

    //other
    [SerializeField] TempEnemyHealth HP;
    [SerializeField] float toungeIndicatorTime;
    float toungeIndicatorCount;
    float toungeIndicatorCount2;
    float currentYScale;
    float fallCount;
    float currentYpos;
    Animator anim;
    [SerializeField] Animator anim2;
    [SerializeField] int atkIndex;
    [SerializeField] GameObject mask;
    [SerializeField] phaseManager phaseManager;

    public bool isDead;
    void Start()
    {
        drawAttackByRandomizer1();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fallCount -= Time.deltaTime;
        toungeIndicatorCount -= Time.deltaTime;
        toungeIndicatorCount2 -= Time.deltaTime;
        currentYScale = Mathf.Clamp(currentYScale, 0, 1.5f);
       toungeIndicatorCount -= Time.deltaTime;
        tongueAtkIndicator.transform.localScale = new Vector3(tongueAtkIndicator.transform.localScale.x,currentYScale,tongueAtkIndicator.transform.localScale.z);
    }

    private void FixedUpdate()
    {
        if(toungeIndicatorCount > 0)
        {
            rolloutTongue();
        }
        if(toungeIndicatorCount2 > 0)
        {
            rollinTongue();
        }
        transform.position = new Vector3(transform.position.x, currentYpos, transform.position.z);
    }

    void drawAttackByRandomizer1()
    {
        atkIndex = Mathf.FloorToInt(Random.Range(0, 3));
        if (HP.isDead)
        {
            doDeath();
        }
        else if(atkIndex == 0)
        {
            Invoke("doHandAtk", attackTimeDelay);
        }
        else if(atkIndex == 1)
        {
            Invoke("doTongueAtk", attackTimeDelay);
        }
        else if(atkIndex >= 2)
        {
            Invoke("doFireBallAtk",attackTimeDelay);
        }
        
    }

    void doTongueAtk()
    {
        toungeIndicatorCount = toungeIndicatorTime;
        Invoke("toungeAttacking",toungeIndicatorTime);
    }

    void toungeAttacking()
    {
        tongueAtk.doTongueAttack();
        Invoke("toungeRollingshit", tongueAtkTime);
    }

    void toungeRollingshit()
    {
        toungeIndicatorCount2 = toungeIndicatorTime;
        Invoke("drawAttackByRandomizer1", toungeIndicatorTime);
    }

    void doHandAtk()
    {
        handAtk.SetTrigger("doHandJob");
        Invoke("drawAttackByRandomizer1", handAtkTime);
    }

    void rolloutTongue()
    {
        currentYScale += Time.deltaTime*2;
    }

    void rollinTongue()
    {
        currentYScale -= Time.deltaTime*2;
    }

    void doFireBallAtk()
    {
        fireballAtk.doFireBallAttack();
        Invoke("drawAttackByRandomizer1", fireballAtkTime);
    }

    void doDeath()
    {
        anim.SetTrigger("doDeath");
    }

    public void doFall()
    {
        anim.SetTrigger("doFall");
    }

    public void destroyThis()
    {
        Destroy(gameObject);
        phaseManager.prePhaseTwo();
    }

    public void deactivateMask()
    {
        mask.SetActive(false);
    }

    public void destroyMask()
    {
        anim2.SetTrigger("doDestroy");
    }
}
