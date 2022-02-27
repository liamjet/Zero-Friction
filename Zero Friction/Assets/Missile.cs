using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform firePoint1;
    public Transform firePoint2;
    public GameObject missilePrefab;
    public float shootDelayInSeconds;
    private bool canShoot;


    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (canShoot == true)
        {
            
            Instantiate(missilePrefab, firePoint1.position, firePoint1.rotation);
            Instantiate(missilePrefab, firePoint2.position, firePoint2.rotation);
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
