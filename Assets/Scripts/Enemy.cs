using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]int health = 50;
    [SerializeField]ParticleSystem blood;

    void Update() {
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        blood.Play();
    }
}
