using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBallShooterPhaseOne : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public bool isShooting;
    public float force;
    public float attackTime;
    bool hasShoot;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isShooting && !hasShoot)
        {
            shootFireBall();
            hasShoot = true;
        }
        else if (!isShooting)
        {
            hasShoot = false;
        }
    }

    private void shootFireBall()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation.normalized);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(transform.right * force, ForceMode2D.Impulse);
        if (isShooting)
        {
            Invoke("shootFireBall",attackTime);
        }
    }
}
