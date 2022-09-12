using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    [SerializeField]GameObject notificationUI;

    void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            notificationUI.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            notificationUI.SetActive(false);
        }
    }
}
