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

    public void PlayGame() {
        SceneManager.LoadScene("level1");
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
}
