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
    bool hasShoot;
    bool isPressed;
    float pressDelay = 0.5f;
    float pressCount = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pressCount -= Time.deltaTime;
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        float rota = Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg;
        var q = Quaternion.Euler(0, 0, rota);
        Vector3 angle = q.eulerAngles;
        isShooting = Input.GetMouseButton(0);
        if (pressCount < 0 && Input.GetMouseButtonDown(0))
        {
            pressCount = 1f;
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        
    }

    void exitShooting()
    {
        isPressed = false;
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation.normalized);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
        if (isShooting)
        {
            Invoke("Shoot", attackTime);
        }
    }
}
