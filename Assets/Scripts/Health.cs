using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class Health : MonoBehaviour
{
    public int health = 100;
    [SerializeField]AudioSource hitSound;
    [SerializeField]TextMeshProUGUI healthUI;
    [SerializeField]GameObject deathUI;
    [SerializeField]GameObject gun;
    [SerializeField]GameObject shooter;
    [SerializeField]GameObject crosshair;
    [SerializeField]ParticleSystem blood;
    [SerializeField]AudioMixer mixer;

    void Update() {
        if(healthUI != null) {
            healthUI.text = health.ToString();
        }
        if(health <= 0) {
            Die();
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        hitSound.Play();
        blood.Play();
    }

    void Die() {
        Time.timeScale = 0f;
        deathUI.SetActive(true);
        gun.SetActive(false);
        shooter.SetActive(false);
        crosshair.SetActive(false);
        (GameObject.FindWithTag("Player").GetComponent("Movement") as MonoBehaviour).enabled = false;
        (GameObject.FindWithTag("Player").GetComponent("BulletTime") as MonoBehaviour).enabled = false;
        if(Input.GetKeyDown(KeyCode.R)) {
            Time.timeScale = 1f;
            mixer.SetFloat("pitch", 1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
