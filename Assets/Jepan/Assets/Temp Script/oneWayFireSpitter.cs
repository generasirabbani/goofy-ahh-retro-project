using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oneWayFireSpitter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] playerDetector nearMiniBoss;
    bool nearMiniBossEnabled;
    public GameObject bulletPrefab;
    public float force;
    public float attackTime;
    void Start()
    {
        WaitForShoot();
    }

    // Update is called once per frame
    void Update()
    {
        if (nearMiniBoss.playerIsHere)
        {
            nearMiniBossEnabled = true;
        }
        else
        {
            nearMiniBossEnabled = false;
        }
    }

    void WaitForShoot()
    {
        if (nearMiniBossEnabled)
        {
            shoot();
        }
        else
        {
            Invoke("WaitForShoot", attackTime);
        }
    }

    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation.normalized);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        Invoke("WaitForShoot",attackTime);
    }
}
