using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public AudioManager bruitage;
    public CameraMenuController mainCamera;
    [Header("Menus :")]
    public GameObject mainWindow;
    public GameObject settingsWindow;
    public GameObject closeWindow;

    public static int menuState = 0;

    void Start()
    {
        menuState = 0;

        PlayerPrefs.SetInt("load", 0);
        Cursor.lockState = CursorLockMode.Confined;
    }

    // ============================= MAIN MENU ===================================

    public void ButtonPlay()
    {
        bruitage.PlayButton();
        if (PlayerPrefs.HasKey("dieCounter"))
        {
            PlayerPrefs.SetInt("load", 1);
            SceneManager.LoadScene(PlayerPrefs.GetString("save"));
        }
        SceneManager.LoadScene("Level1");
    }

    public void ButtonSettings()
    {
        bruitage.PlayButton();
        mainWindow.SetActive(false);
        settingsWindow.SetActive(true);

        menuState = 1;
        //mainCamera.Fonction2();
    }

    /*public void ButtonCredits()
    {
        bruitage.PlayButton();
        SceneManager.LoadScene("Credits");
    }*/

    public void ButtonQuit()
    {
        bruitage.PlayButton();
        mainWindow.SetActive(false);
        closeWindow.SetActive(true);
    }

    // ============================= SETTINGS MENU ===============================

    public void ButtonCloseSettings()
    {
        bruitage.PlayButton();
        settingsWindow.SetActive(false);
        mainWindow.SetActive(true);

        //mainCamera.Fonction1();
        menuState =  0;
    }

    // ============================= QUIT MENU ===================================

    public void ButtonCancelQuit()
    {
        bruitage.PlayButton();
        closeWindow.SetActive(false);
        mainWindow.SetActive(true);
    }

    public void ButtonConfirmQuit()
    {
        bruitage.PlayButton();
        Application.Quit();
    }
}