using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]GameObject interactUI;

    void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E)) {
                int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(nextScene);
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(false);
        }
    }
}
