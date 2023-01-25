using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        // Shooting Logic
        // To spawn object we use instantiate, the prefab, the position of spawn, then the rotation.
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
