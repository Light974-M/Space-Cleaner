using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    public AudioManager audioManager;
    public string nameOfMainMenu = "menu";
    public GameObject mainPausePanel;
    public GameObject quitToMenuPanel;
    public GameObject quitGamePanel;
    public GameObject settingsPanel;

    public void Pause()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        LevelManager.isPause = true;
    }

    // =========================================== MAIN PAUSE ===================================

    public void ButtonResume()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
        LevelManager.isPause = false;
    }

    public void ButtonQuitToMenu()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        quitToMenuPanel.SetActive(true);
    }

    public void ButtonQuitToWindows()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        quitGamePanel.SetActive(true);
    }

    public void ButtonSettings()
    {
        audioManager.PlayButton();
        mainPausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ButtonCloseSettings()
    {
        audioManager.PlayButton();
        settingsPanel.SetActive(false);
        mainPausePanel.SetActive(true);
    }

    // ========================================== CONFIRM RETURN MENU ===================================

    public void ButtonYesGoMenu()
    {
        audioManager.PlayButton();
        PlayerPrefs.SetString("save", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("dieCounter", DieCounterController.matriculationNumber);
        SceneManager.LoadScene(nameOfMainMenu);
    }

    public void ButtonNoGoMenu()
    {
        audioManager.PlayButton();
        quitToMenuPanel.SetActive(false);
        mainPausePanel.SetActive(true);

    }

    // ========================================= CONFIRM QUIT GAME =========================================

    public void ButtonYesQuitGame()
    {
        audioManager.PlayButton();
        PlayerPrefs.SetString("save", SceneManager.GetActiveScene().name);
        PlayerPrefs.SetInt("dieCounter", DieCounterController.matriculationNumber);
        Application.Quit();
    }

    public void ButtonNoQuitGame()
    {
        audioManager.PlayButton();
        quitGamePanel.SetActive(false);
        mainPausePanel.SetActive(true);
    }
}