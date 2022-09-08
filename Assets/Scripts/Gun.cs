using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]GameObject bullet;
    [SerializeField]ParticleSystem muzzleFlash;
    AudioSource gunshot;

    void Start()
    {
        gunshot = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        muzzleFlash.Play();
        gunshot.Play();
        GameObject shot = Instantiate(bullet, transform.position, transform.rotation);
    }
}
