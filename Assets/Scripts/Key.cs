using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField]GameObject block;
    [SerializeField]GameObject notification;
    [SerializeField]GameObject interactUI;
    [SerializeField]AudioSource interactSound;

    void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(true);
            if(Input.GetKey(KeyCode.E)) {
                interactSound.Play();
                block.SetActive(false);
                notification.SetActive(false);
                interactUI.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(false);
        }
    }
}
