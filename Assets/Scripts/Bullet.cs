using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]float bulletSpeed;
    [SerializeField]float bulletTime;

    void Update() {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        Destroy(gameObject, bulletTime);
    }
}
