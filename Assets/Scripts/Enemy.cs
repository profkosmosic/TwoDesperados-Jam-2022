using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]int health = 50;
    [SerializeField]ParticleSystem blood;
    [SerializeField]Animator anim;
    bool isDead = false;

    void Update() {
        if(health <= 0 && !isDead) {
            Die();
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        blood.Play();
    }

    void Die() {
        anim.SetTrigger("Death");
        (gameObject.GetComponent("EnemyAI") as MonoBehaviour).enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        isDead = true;
    }
}
