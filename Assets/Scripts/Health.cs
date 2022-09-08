using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField]int health = 100;
    [SerializeField]AudioSource hitSound;
    [SerializeField]TextMeshProUGUI healthUI;

    void Update() {
        if(healthUI != null) {
            healthUI.text = health + " HP".ToString();
        }
        if(health <= 0) {
            Debug.Log("You're dead!");
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        hitSound.Play();
    }
}
