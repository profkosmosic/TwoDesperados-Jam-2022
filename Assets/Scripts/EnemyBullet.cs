using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]float bulletSpeed;
    [SerializeField]float bulletTime;
    [SerializeField]int damage;
    Health player;

    void Start() {
        player = FindObjectOfType<Health>();
    }

    void Update() {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
        Destroy(gameObject, bulletTime);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            Destroy(gameObject);
            player.TakeDamage(damage);
        }
        if(other.tag == "Obstacle") {
            Destroy(gameObject);
        }
    }
}
