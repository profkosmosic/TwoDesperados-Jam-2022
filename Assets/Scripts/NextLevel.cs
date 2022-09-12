using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField]GameObject interactUI;
    [SerializeField]GameObject fadeOut;
    [SerializeField]GameObject loading;

    void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(true);
            if(Input.GetKey(KeyCode.E)) {
                StartCoroutine(GoToNextLevel());
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.tag == "Player") {
            interactUI.SetActive(false);
        }
    }

    IEnumerator GoToNextLevel() {
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        loading.SetActive(true);
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextScene);
    }
}
