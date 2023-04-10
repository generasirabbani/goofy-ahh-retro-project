using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tempBanaspatiShoot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce = 20f;
    public Vector3 mousePos;
    public Camera cam;
    public float attackTime = 0.2f;

    bool isShooting;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float rota = Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg;
        var q = Quaternion.Euler(0, 0, rota);
        Vector3 angle = q.eulerAngles;
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            StartCoroutine(Shoot(angle));
        }
        if (Input.GetMouseButtonUp(0))
        {
            isShooting = false;
        }
        //if (isShooting)
        //{
            
        //}
    }

    private IEnumerator Shoot(Vector3 angle)
    {
        yield return new WaitForSeconds(attackTime);
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation.normalized);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        if (isShooting)
        {
            StartCoroutine(Shoot(angle));
        }
        //animator.SetTrigger("Punch");
    }
}
