using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public Button play;
    public Button settings;
    public Button quit;
    public Button generalSettings;
    public Button qualitySettings;
    public Button soundSettings;
    public Button returnBack;
    public Button yes;
    public Button no;

    public static int menuState = 0;

    void Start()
    {
        play.onClick.AddListener(PlayGame);
        settings.onClick.AddListener(SettingsGame);
        quit.onClick.AddListener(QuitGame);
        returnBack.onClick.AddListener(Return);
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
    }

    void Update()
    {
        
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("max");
    }

    public void SettingsGame()
    {
        menuState = 1;
    }

    public void QuitGame()
    {
        menuState = -1;
    }

    public void Return()
    {
        menuState -= 1;
    }

    public void No()
    {
        menuState = 0;
    }

    public void Yes()
    {
        Application.Quit();
    }
}
