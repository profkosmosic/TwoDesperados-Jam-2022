using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    [SerializeField]ParticleSystem muzzleFlash;
    [SerializeField]float fireRate = 12f;
    [SerializeField]int maxAmmo = 12;
    [SerializeField]int currentAmmo;
    float nextTimeToFire = 0f;
    AudioSource gunshot;

    void Start()
    {
        currentAmmo = maxAmmo;
        gunshot = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R)) {
            StartCoroutine(Reload());
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0) {
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }
    }

    void Shoot() {
        currentAmmo--;
        muzzleFlash.Play();
        gunshot.Play();
        GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
    }

    IEnumerator Reload() {
        yield return new WaitForSeconds(1f);
        currentAmmo = maxAmmo;
    }
}
