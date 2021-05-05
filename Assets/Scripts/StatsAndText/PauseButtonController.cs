using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseButtonController : MonoBehaviour
{
    public Button resume;
    public Button quitToMenu;
    public Button quitToWindows;
    public Button no;
    public Button yes;

    public static bool isResuming = false;

    public static int sureToQuitState = 0;

    void Start()
    {
        resume.onClick.AddListener(Resume);
        quitToMenu.onClick.AddListener(QuitToMenu);
        quitToWindows.onClick.AddListener(QuitToWindows);
        no.onClick.AddListener(No);
        yes.onClick.AddListener(Yes);
    }

    void Update()
    {
        
    }

    private void Resume()
    {
        isResuming = true;
    }

    private void QuitToMenu()
    {
        sureToQuitState = 1;
    }

    private void QuitToWindows()
    {
        sureToQuitState = 2;
    }

    private void Yes()
    {
        if(sureToQuitState == 1)
        {
            SceneManager.LoadScene("menu");
        }

        if (sureToQuitState == 2)
        {
            Application.Quit();
        }
    }

    private void No()
    {
        sureToQuitState = 0;
    }
}
