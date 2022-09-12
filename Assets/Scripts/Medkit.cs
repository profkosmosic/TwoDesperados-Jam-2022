using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medkit : MonoBehaviour
{
    [SerializeField]Health player;
    [SerializeField]int amount = 25;
    [SerializeField]GameObject interactUI;

    void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                player.health += amount;
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
