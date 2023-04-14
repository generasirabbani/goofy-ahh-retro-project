using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallAttack : MonoBehaviour
{
    // Start is called before the first frame update
    public fireBallShooterPhaseOne spot1, spot2, spot3, spot4, spot5, spot6, spot7, spot8;
    public float timePattern = 2,timeDelay = 0.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void doFireBallAttack()
    {
        Invoke("firstPattern", timeDelay);

    }

    void firstPattern()
    {
        spot1.isShooting = true;
        spot3.isShooting = true;
        spot5.isShooting = true;
        spot7.isShooting = true;
        StartCoroutine(changePatternTo("secondPattern"));
    }

    void secondPattern()
    {
        spot2.isShooting = true;
        spot4.isShooting = true;
        spot6.isShooting = true;
        spot8.isShooting = true;
        StartCoroutine(changePatternTo("thirdPattern"));
    }

    void thirdPattern()
    {
        spot1.isShooting = true;
        spot3.isShooting = true;
        spot5.isShooting = true;
        spot7.isShooting = true;
        spot2.isShooting = true;
        spot4.isShooting = true;
        spot6.isShooting = true;
        spot8.isShooting = true;
        StartCoroutine(changePatternTo("doNothing"));
    }

    private IEnumerator changePatternTo(string pattern)
    {
        yield return new WaitForSeconds(timePattern);
        spot1.isShooting = false;
        spot3.isShooting = false;
        spot5.isShooting = false;
        spot7.isShooting = false;
        spot2.isShooting = false;
        spot4.isShooting = false;
        spot6.isShooting = false;
        spot8.isShooting = false;
        Invoke(pattern,timeDelay);
    }

    void doNothing()
    {

    }
}
