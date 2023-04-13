using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class phaseOne : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("attackScript")]
    [SerializeField] TongueAttack tongueAtk;
    [SerializeField] Animator handAtk;


    [Header("attack Addons")]
    [SerializeField] GameObject tongueAtkIndicator;

    [Header("value")]
    [SerializeField] float attackTimeDelay = 5f;
    [SerializeField] float tongueAtkTime = 15f;
    [SerializeField] float handAtkTime = 15f;

    //other
    [SerializeField] float toungeIndicatorTime;
    float toungeIndicatorCount;
    float toungeIndicatorCount2;
    float currentYScale;
    [SerializeField] int atkIndex;

    public bool isDead;
    void Start()
    {
        drawAttackByRandomizer1();
    }

    // Update is called once per frame
    void Update()
    {
        toungeIndicatorCount -= Time.deltaTime;
        toungeIndicatorCount2 -= Time.deltaTime;
        currentYScale = Mathf.Clamp(currentYScale, 0, 1);
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
    }

    void drawAttackByRandomizer1()
    {
        atkIndex = Mathf.FloorToInt(Random.Range(0, 3));
        if(atkIndex == 0)
        {
            Invoke("doHandAtk", attackTimeDelay);
        }
        else if(atkIndex == 1)
        {
            Invoke("doTongueAtk", attackTimeDelay);
        }
        else if(atkIndex >= 2)
        {
            Invoke("drawAttackByRandomizer1",attackTimeDelay);
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
        currentYScale += Time.deltaTime;
    }

    void rollinTongue()
    {
        currentYScale -= Time.deltaTime;
    }

}
