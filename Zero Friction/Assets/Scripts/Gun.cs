using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject bulletPrefab;
    public float shootDelayInSeconds;
    private bool canShoot;
    private bool shootLeft;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        shootLeft = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (canShoot == true)
        {
            if (shootLeft == true)
            {
                Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
                shootLeft = false;
            }
            else
            {
                Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
                shootLeft = true;
            }
            canShoot = false;
            StartCoroutine(shootDelay(shootDelayInSeconds));
        }
        
    }

    IEnumerator shootDelay(float time)
    {
        yield return new WaitForSeconds(time);
        canShoot = true;
    }
}
