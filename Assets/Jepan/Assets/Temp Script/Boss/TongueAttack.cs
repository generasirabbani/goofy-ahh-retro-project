using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float timeAttack = 1f;
    public float timeRecovery = 3f;
    public float stayTime = 3.25f;
    float outmapPos = -55;
    float targetPos = 0;
    public float attackSpeed;
    public float recoverySpeed;
    [SerializeField] float currentXpos;
    [SerializeField] float targetYPos;
    float atkTimeCount = -0.01f;
    float recoverTimeCount = -0.01f;
    void Start()
    {
        //attackSpeed = Mathf.Abs(outmapPos - targetPos)/timeAttack;
        //recoverySpeed = Mathf.Abs(outmapPos - targetPos)/timeRecovery;
        currentXpos = outmapPos;
    }

    // Update is called once per frame
    void Update()
    {
        atkTimeCount -= Time.deltaTime;
        recoverTimeCount -= Time.deltaTime;
        currentXpos = Mathf.Clamp(currentXpos, outmapPos,targetPos);
        transform.position = new Vector3(currentXpos, targetYPos, 0);
    }

    private void FixedUpdate()
    {
        if(atkTimeCount > 0)
        {
            tongueSlide();
        }
        if(recoverTimeCount > 0)
        {
            tongueSlideBack();
        }
    }

    public void doTongueAttack()
    {
        targetYPos = player.transform.position.y;
        atkTimeCount = timeAttack;
        Invoke("doTongueBack", timeAttack + stayTime);
    }

    void tongueSlide()
    {
        currentXpos += Time.deltaTime * attackSpeed;
    }

    void doTongueBack()
    {
        recoverTimeCount = timeRecovery;
    }

    void stayOnMap()
    {
        Invoke("tongueSlideBack", stayTime);
    }

    void tongueSlideBack()
    {
        currentXpos -= Time.deltaTime * recoverySpeed;
    }

    void doNothing()
    {

    }

}
