using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    [SerializeField]ParticleSystem muzzleFlash;
    [SerializeField]float fireRate = 12f;
    [SerializeField]int maxAmmo = 12;
    [SerializeField]TextMeshProUGUI ammoUI;
    int currentAmmo;
    float nextTimeToFire = 0f;
    bool isReloading = false;
    AudioSource gunshot;

    void Start()
    {
        currentAmmo = maxAmmo;
        gunshot = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(ammoUI != null) {
            ammoUI.text = currentAmmo + "-" + maxAmmo.ToString();
        }

        if(Input.GetKeyDown(KeyCode.R) && !isReloading) {
            StartCoroutine(Reload());
        }

        if(Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0 && !isReloading) {
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
        isReloading = true;
        yield return new WaitForSeconds(1f);
        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
