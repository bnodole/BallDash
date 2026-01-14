using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pauseUI;
    public GameObject gameUI;
    public GameObject settingsUI;
    public GameObject homeUI;
    public GameObject shopUI;
    public void GameStart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
        gameUI.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameUI.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ShopButton()
    {
        shopUI.SetActive(true);
        homeUI.SetActive(false);
    }

    public void Settings()
    {
        settingsUI.SetActive(true);
        homeUI.SetActive(false);
    }

    public void CrossButton()
    {
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
        homeUI.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
