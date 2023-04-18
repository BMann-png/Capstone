using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Shooter : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [Range(0.5f, 4.0f)][SerializeField] float fireDelay;
    [SerializeField] Transform bulletSpawn;
    [SerializeField] bool isFiring = false;
    float currentTime = 0.0f;

    private void Start()
    {
        currentTime = fireDelay;  
    }

    private void FixedUpdate()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0 && isFiring)
        {
            GameObject bullet = Instantiate(bulletPrefab,
                bulletSpawn.position,
                Quaternion.LookRotation(transform.up, Vector3.up));

            currentTime = fireDelay;
        }
    }

    public void OnFire(bool firing)
    {
        isFiring = firing;
    }

    public void OnFireDelayChanged(string newFireDelay)
    {
        if (float.TryParse(newFireDelay, out float f))
        {
            fireDelay = f;
        }
    }
}
