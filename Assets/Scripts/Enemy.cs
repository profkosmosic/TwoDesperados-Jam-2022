using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]int health = 50;
    [SerializeField]ParticleSystem blood;
    [SerializeField]Animator anim;
    AudioSource death;
    bool isDead = false;
    int deathAnim;

    void Start() {
        System.Random random = new System.Random ();
		deathAnim = random.Next (1, 4);
        death = gameObject.GetComponent<AudioSource>();
    }

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
        if(deathAnim == 1) anim.SetTrigger("Death1");
        else if(deathAnim == 2) anim.SetTrigger("Death2");
        else anim.SetTrigger("Death3");
        (gameObject.GetComponent("EnemyAI") as MonoBehaviour).enabled = false;
        this.GetComponent<BoxCollider>().enabled = false;
        death.Play();
        isDead = true;
    }
}
