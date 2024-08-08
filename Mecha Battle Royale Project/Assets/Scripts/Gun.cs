using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform muzzleTransform;
    // public Transform muzzleTransform;
    public float projectileSpeed = 20f;
    public float fireRate = 0.5f;

    public int magazineSize = 10;
    public float reloadTime = 2f;
    public float projectileLifetime = 5f;

    private int currentAmmo;
    private float nextFireTime;
    private bool isReloading = false;
    private bool canShoot = false;

    void Start()
    {
        currentAmmo = magazineSize;
    }

    void Update()
    {
        if(!canShoot){
            if (isReloading)
                return;

            if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
            {
                if (currentAmmo > 0)
                {
                    Shoot();
                    nextFireTime = Time.time + fireRate;
                }
                else
                {
                    StartCoroutine(Reload());
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                StartCoroutine(Reload());
            }
        }
    }

    void Shoot()
    {
        // Instantiate the projectile at the muzzle's position and rotation
        GameObject projectile = Instantiate(projectilePrefab, muzzleTransform.position, muzzleTransform.rotation);
        
        // Get the Rigidbody component of the projectile and set its velocity
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = muzzleTransform.forward * projectileSpeed;
        }

        Destroy(projectile, projectileLifetime);

        currentAmmo--;
    }

    IEnumerator Reload()
    {
        isReloading = true;

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = magazineSize;
        isReloading = false;
    }
}
