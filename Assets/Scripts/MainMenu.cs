using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]GameObject playButton;
    [SerializeField]GameObject controlButton;
    [SerializeField]GameObject quitButton;
    [SerializeField]GameObject controlScreen;
    [SerializeField]GameObject backToMenuButton;
    [SerializeField]GameObject fadeOut;
    [SerializeField]GameObject loading;

    public void PlayGame() {
        StartCoroutine(StartLevel());
    }

    public void Controls() {
        playButton.SetActive(false);
        controlButton.SetActive(false);
        quitButton.SetActive(false);
        controlScreen.SetActive(true);
        backToMenuButton.SetActive(true);
    }

    public void BackToMenu() {
        playButton.SetActive(true);
        controlButton.SetActive(true);
        quitButton.SetActive(true);
        controlScreen.SetActive(false);
        backToMenuButton.SetActive(false);
    }

    public void QuitGame() {
        Application.Quit();
    }

    IEnumerator StartLevel() {
        if(MusicPlay.Music.gameObject != null) {
            MusicPlay.Music.gameObject.GetComponent<AudioSource>().Play();
        }
        fadeOut.SetActive(true);
        yield return new WaitForSeconds(1f);
        loading.SetActive(true);
        SceneManager.LoadScene("level1");
    }
}
