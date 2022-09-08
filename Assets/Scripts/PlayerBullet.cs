using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField]float bulletSpeed;
    [SerializeField]float bulletTime;
    [SerializeField]int damage;

    void Update() {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        Destroy(gameObject, bulletTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Enemy") {
            Destroy(gameObject);
            Enemy enemy = other.transform.GetComponent<Enemy>();
            enemy.TakeDamage(damage);
        }
    }
}
